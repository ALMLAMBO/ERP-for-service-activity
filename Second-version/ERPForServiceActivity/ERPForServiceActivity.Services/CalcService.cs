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
		
		public async Task<double> CalcRepairPrice(int id) {
			double total = 0;
			FirestoreDb db = connection.GetFirestoreDb();

			QuerySnapshot snapshot = await db
				.Collection("service-repairs")
				.WhereEqualTo("RepairId", id)
				.Limit(1)
				.GetSnapshotAsync();

			Repair repair = snapshot
				.FirstOrDefault()
				.ConvertTo<Repair>();

			if(repair.RepairStatus.Contains("OOW")) {
				total += repair.TechnicianLabor;

				QuerySnapshot qs = await db
					.Collection("repair-parts")
					.WhereEqualTo("RepairId", id)
					.Limit(1)
					.GetSnapshotAsync();

				RequestPartBindingModel model = qs
					.FirstOrDefault()
					.ConvertTo<RequestPartBindingModel>();

				model.PartsForRepair
					.ToList()
					.ForEach(async x => {
						QuerySnapshot qst = await db
							.Collection("warehouse-parts")
							.Document("bcyvKBFBWE6DxnvIQ1Kn")
							.Collection("parts")
							.WhereEqualTo("PartNumber", x.Key)
							.Limit(1)
							.GetSnapshotAsync();

						WarehousePart part = qst
							.FirstOrDefault()
							.ConvertTo<WarehousePart>();

						total += part.Price * x.Value;
					});
			}
			else {
				total = 0;
			}

			return total;
		}
	}
}
