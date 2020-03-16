using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Google.Cloud.Firestore;
using ERPForServiceActivity.Data;
using ERPForServiceActivity.Models.Repairs;
using ERPForServiceActivity.Models.Warehouse;
using ERPForServiceActivity.Services.Interfaces;
using ERPForServiceActivity.CommonModels.BindingModels.WarehouseParts;

namespace ERPForServiceActivity.Services {
	public class CalcService : ICalcService {
		private ConnectionConfig connection = 
			new ConnectionConfig();
		
		public Task<double> CalcRepairPrice(int id) {
			double total = 0;
			FirestoreDb db = connection.GetFirestoreDb();

			QuerySnapshot snapshot = db
				.Collection("service-repairs")
				.WhereEqualTo("RepairId", id)
				.Limit(1)
				.GetSnapshotAsync()
				.Result;

			Repair repair = snapshot
				.FirstOrDefault()
				.ConvertTo<Repair>();

			if(repair.RepairStatus.Contains("OOW") || 
				repair.RepairStatus.Equals("Awaiting payment")) {
				total += repair.TechnicianLabor;

				QuerySnapshot qs = db
					.Collection("repair-parts")
					.WhereEqualTo("RepairId", id)
					.Limit(1)
					.GetSnapshotAsync()
					.Result;

				RequestPartBindingModel model = qs
					.FirstOrDefault()
					.ConvertTo<RequestPartBindingModel>();

				foreach (KeyValuePair<string, int> x in model.PartsForRepair) {
					QuerySnapshot qst = db
							.Collection("warehouse-parts")
							.Document("bcyvKBFBWE6DxnvIQ1Kn")
							.Collection("parts")
							.WhereEqualTo("PartNumber", x.Key)
							.Limit(1)
							.GetSnapshotAsync()
							.Result;

					WarehousePart part = qst
						.FirstOrDefault()
						.ConvertTo<WarehousePart>();

					total += part.Price * x.Value;
				}

				qs
					.FirstOrDefault()
					.Reference
					.UpdateAsync("Total", total);
			}
			else {
				total = 0;
			}

			return Task.FromResult(total);
		}
	}
}
