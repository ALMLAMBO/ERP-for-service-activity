using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Google.Cloud.Firestore;
using ERPForServiceActivity.Data;
using ERPForServiceActivity.Models.Repairs;
using ERPForServiceActivity.Services.Interfaces;
using ERPForServiceActivity.CommonModels.ViewModels.Checkup;

namespace ERPForServiceActivity.Services {
	public class CheckupService : ICheckupService {
		private ConnectionConfig connection = 
			new ConnectionConfig();

		public async Task<List<RepairStatusCheckupViewModel>> 
			StatusCheckup(string status, 
			DateTime begin, DateTime end) {

			FirestoreDb db = connection.GetFirestoreDb();
			List<RepairStatusCheckupViewModel> result =
				new List<RepairStatusCheckupViewModel>();

			QuerySnapshot snapshot = await db
				.Collection("service-repairs")
				.WhereGreaterThanOrEqualTo("CreatedAt", begin)
				.WhereLessThanOrEqualTo("CreatedAt", end)
				.WhereEqualTo("RepairStatus", status)
				.GetSnapshotAsync();

			snapshot.Documents
				.ToList()
				.ForEach(x => {
					Repair repair = x.ConvertTo<Repair>();

					result.Add(new RepairStatusCheckupViewModel() {
						RepairId = repair.RepairId,
						Status = repair.RepairStatus,
						GoingToAddress = repair.GoingToAddress,
						UnitModel = repair.ApplianceModel,
						CustomerAddress = repair.CustomerAddress,
						CustomerPhoneNumber = repair.CustomerPhoneNumber
					});
				});

			return result;
		}

		public async Task<List<TechniciаnCheckupViewModel>>
			TechnicianCheckup(string serviceName, 
			DateTime begin, DateTime end) {

			FirestoreDb db = connection.GetFirestoreDb();
			List<TechniciаnCheckupViewModel> result =
				new List<TechniciаnCheckupViewModel>();

			QuerySnapshot snapshot = await db
				.Collection("service-repairs")
				.GetSnapshotAsync();

			Dictionary<string, DocumentSnapshot> dictionary = snapshot
				.Documents
				.Cast<KeyValuePair<string, DocumentSnapshot>>()
				.ToDictionary(x => x.Key, x => x.Value);

			dictionary
				.GroupBy(x => x.Key)
				.ToList()
				.ForEach(x => {
					double labor = 0;

					x.ToList()
						.ForEach(y => {
							labor += y.Value
								.ConvertTo<Repair>()
								.TechnicianLabor;
						});

					result.Add(new TechniciаnCheckupViewModel() {
						Name = x.Key,
						Labor = labor
					});
				});

			return result;
		}

		public async Task ExoprtTechniciansCheckupToExcel(
			List<TechniciаnCheckupViewModel> results) {

			IWorkbook workbook = new XSSFWorkbook();
			ISheet sheet = workbook.CreateSheet();
			IRow header = sheet.CreateRow(0);
			header.CreateCell(0).SetCellValue("Techician name");
			header.CreateCell(1).SetCellValue("Labor");

			using (FileStream fs = new FileStream(
				@"C:\Users\aleks\Desktop\labor.xlsx", 
				FileMode.Create, FileAccess.Write)) {

				for (int i = 0; i < results.Count; i++) {
					IRow row = sheet.CreateRow(i + 1);
					row.CreateCell(0).SetCellValue(results[i].Name);
					row.CreateCell(1).SetCellValue(
						results[i].Labor.ToString());
				}

				await Task.Run(() => {
					workbook.Write(fs);
				});
			}
		}

		public async Task ExportRepairStatusCheckupToExcel(
			List<RepairStatusCheckupViewModel> results) {

			IWorkbook workbook = new XSSFWorkbook();
			ISheet sheet = workbook.CreateSheet();
			IRow header = sheet.CreateRow(0);
			header.CreateCell(0).SetCellValue("Repair id");
			header.CreateCell(1).SetCellValue("Status");
			header.CreateCell(2).SetCellValue("Unit model");
			header.CreateCell(3).SetCellValue("Going to address");
			header.CreateCell(4).SetCellValue("Address");
			header.CreateCell(5).SetCellValue("Phone number");

			using (FileStream fs = new FileStream(
				@"C:\Users\aleks\Desktop\status.xlsx", 
				FileMode.Create, FileAccess.Write)) {

				for (int i = 0; i < results.Count; i++) {
					IRow row = sheet.CreateRow(i + 1);
					row.CreateCell(0).SetCellValue(results[i].RepairId);
					row.CreateCell(1).SetCellValue(results[i].Status);
					row.CreateCell(2).SetCellValue(results[i].UnitModel);
					row.CreateCell(3).SetCellValue(results[i].GoingToAddress);
					row.CreateCell(4).SetCellValue(results[i].CustomerAddress);
					row.CreateCell(5).SetCellValue(results[i].CustomerPhoneNumber);
				}

				await Task.Run(() => {
					workbook.Write(fs);
				});
			}
		}
	}
}
