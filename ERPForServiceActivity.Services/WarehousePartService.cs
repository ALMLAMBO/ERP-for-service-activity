using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Google.Cloud.Firestore;
using ERPForServiceActivity.Data;
using ERPForServiceActivity.Models.Warehouse;
using ERPForServiceActivity.Services.Interfaces;
using ERPForServiceActivity.CommonModels.ViewModels.Warehouse;
using ERPForServiceActivity.CommonModels.BindingModels.WarehouseParts;

namespace ERPForServiceActivity.Services {
	public class WarehousePartService : IWarehousePartService {
		private ConnectionConfig connection = new ConnectionConfig();

		public async void AddWarehousePart(
			AddWarehousePartBindingModel model,
			string serviceName) {

			FirestoreDb db = connection.GetFirestoreDb();
			CollectionReference colRef = db
				.Collection("warehouse-parts")
				.Document("bcyvKBFBWE6DxnvIQ1Kn")
				.Collection("parts");

			WarehousePart newPart = new WarehousePart(model);
			QuerySnapshot partsWithSamePN = await colRef
				.WhereEqualTo("PartNumber", newPart.PartNumber)
				.GetSnapshotAsync();

			if(partsWithSamePN.Documents.Count == 0) {
				//QuerySnapshot partsWithSameSPN = null; 
				
				if(newPart.SubstituteParts.Count != 0) {
					//QuerySnapshot query = await colRef
					//.WhereArrayContains("SubstituteParts",
					//	newPart.SubstituteParts[0])
					//.GetSnapshotAsync();
					//
					//partsWithSameSPN = query;
				}

				//if(partsWithSameSPN == null) {
				//	await RunTransaction(newPart, colRef);
				//	return;
				//}
				//else {
				//	WarehousePart lastPartWithSameSPN =
				//		GetLastPartWithSamePnOrSpn(partsWithSameSPN);
				//
				//	newPart.SubstituteParts =
				//		GetUniqueElements(
				//			newPart.SubstituteParts, 
				//			lastPartWithSameSPN.SubstituteParts);
				//
				//	newPart.Model =
				//		GetUniqueElements(
				//			newPart.Model,
				//			lastPartWithSameSPN.Model);
				//
				//	List<WarehousePart> parts = new List<WarehousePart>();
				//	foreach (DocumentSnapshot ds in 
				//		partsWithSameSPN.Documents) {
				//
				//		if (!ds.ConvertTo<WarehousePart>()
				//			.Equals(lastPartWithSameSPN)) {
				//
				//			parts.Add(ds.ConvertTo<WarehousePart>());
				//		}
				//	}
				//
				//	lastPartWithSameSPN.SubstituteParts = 
				//		newPart.SubstituteParts;
				//
				//	lastPartWithSameSPN.Model =
				//		newPart.Model;
				//
				//	await RunTransaction(newPart, colRef);
				//
				//	UpdateAllRecordsWithSamePnOrSPN(
				//		lastPartWithSameSPN, 
				//		colRef, partsWithSameSPN);
				//}

				await RunTransaction(newPart, colRef);
			}
			else {
				WarehousePart lastPartWithSamePN =
					GetLastPartWithSamePnOrSpn(partsWithSamePN);

				newPart.SubstituteParts =
						GetUniqueElements(
							newPart.SubstituteParts,
							lastPartWithSamePN.SubstituteParts);

				newPart.Model =
					GetUniqueElements(
						newPart.Model,
						lastPartWithSamePN.Model);

				newPart.Availability = partsWithSamePN.Count + 1;

				await RunTransaction(newPart, colRef);
				
				UpdateAllRecordsWithSamePnOrSPN(
					newPart, colRef, partsWithSamePN);
			}
		}

		private WarehousePart GetLastPartWithSamePnOrSpn(
			QuerySnapshot snapshot) {

			return new List<DocumentSnapshot>(
				snapshot.Documents)
				.OrderByDescending(ds =>
					ds.GetValue<DateTime>("ReceivedDate"))
				.FirstOrDefault()
				.ConvertTo<WarehousePart>();
		}

		private void UpdateAllRecordsWithSamePnOrSPN(
			WarehousePart lastPartWithSameSPN, 
			CollectionReference colRef,
			QuerySnapshot snapshot) {

			snapshot.Documents
				.ToList()
				.ForEach(async ds => {
					WarehousePart part = ds
						.ConvertTo<WarehousePart>();

					part.SubstituteParts =
						lastPartWithSameSPN.SubstituteParts;

					part.Model =
						lastPartWithSameSPN.Model;

					part.Availability = 
						lastPartWithSameSPN.Availability;

					Dictionary<string, object> partAsDictionary =
						ConvertPartToDictionary(part);

					await colRef.Database.RunTransactionAsync(async t => {
						await ds.Reference.UpdateAsync(partAsDictionary);
					});
				});
		}

		private Dictionary<string, object> 
			ConvertPartToDictionary(WarehousePart part) {

			return part.GetType()
				.GetProperties(BindingFlags.Instance | 
					BindingFlags.Public)
				.ToDictionary(prop => prop.Name, 
					prop => prop.GetValue(part, null));
		}

		private async Task 
			RunTransaction(
			WarehousePart newPart,
			CollectionReference colRef) {
			
			await colRef.Database
				.RunTransactionAsync(async transaction => {
					await colRef.AddAsync(newPart);
			});
		}

		private List<string> GetUniqueElements(
			List<string> oldData, List<string> newData) {

			oldData.AddRange(newData);
			HashSet<string> data = new HashSet<string>(oldData);

			return data.ToList();
		}

		public async Task<List<WarehousePartViewModel>> 
			GetAllParts(string serviceName) {
			
			FirestoreDb db = connection.GetFirestoreDb();
			List<WarehousePartViewModel> parts = 
				new List<WarehousePartViewModel>();

			Query query = db.Collection("warehouse-parts")
				.Document("bcyvKBFBWE6DxnvIQ1Kn")
				.Collection("parts")
				.WhereGreaterThanOrEqualTo("Availability", 1);

			QuerySnapshot snapshot = await query.GetSnapshotAsync();
			foreach(DocumentSnapshot ds in snapshot.Documents) {
				if(ds.Exists) {
					WarehousePartViewModel part = 
						ConvertDsToViewModel(ds);

					parts.Add(part);
				}
			}

			return parts;
		}

		private WarehousePartViewModel 
			ConvertDsToViewModel(DocumentSnapshot ds) {

			return new WarehousePartViewModel() {
				PartNumber = ds.GetValue<string>("PartNumber"),
				Availability = ds.GetValue<int>("Availability"),
				Model = ds.GetValue<List<string>>("Model"),
				Description = ds.GetValue<string>("Description"),
				Brand = ds.GetValue<string>("Brand"),
				SubstituteParts = ds.GetValue<List<string>>("SubstituteParts"),
				Price = ds.GetValue<double>("Price"),
				Invoice = ds.GetValue<string>("Invoice"),
				InvoiceDate = ds.GetValue<DateTime>("InvoiceDate"),
				ReceivedDate = ds.GetValue<DateTime>("ReceivedDate")
			};
		}

		public List<WarehousePartViewModel> SearchItems(
			string data, List<WarehousePartViewModel> parts) {
			
			List<WarehousePartViewModel> result = 
				new List<WarehousePartViewModel>();

			Regex regex;
			string searchData = string.Empty;
			if(data.StartsWith("*") && 
				data.EndsWith("*")) {

				searchData = data.Substring(1, data.Length - 2);
				regex = new Regex($".*{searchData}.*");
			}
			else if(data.StartsWith("*")) {
				searchData = data.Substring(1);
				regex = new Regex($".*{searchData}");
			}
			else if(data.EndsWith("*")) {
				searchData = data.Substring(0, data.Length - 1);
				regex = new Regex($"{searchData}.*");
			}
			else if(data.IndexOf("*") != 0 && 
				data.LastIndexOf("*") != data.Length - 1) {

				searchData = data.Substring(
					data.IndexOf("*"), data.LastIndexOf("*"));

				regex = new Regex($".*{searchData}.*");
			}
			else {
				regex = new Regex(data);
			}

			result = parts
				.Where(part => regex.Match(part.PartNumber).Success)
				.ToList();

			if(result.Count == 0) {
				result = parts
					.Where(part => part.Model
						.Any(str => regex.Match(str).Success))
					.ToList();

				if(result.Count == 0) {
					result = parts
						.Where(part => part.SubstituteParts
							.Any(str => regex.Match(str).Success))
						.ToList();

					if(result.Count == 0) {
						result = new List<WarehousePartViewModel>();
					}
				}
			}
			else {
				result.AddRange(parts
					.Where(part => part.SubstituteParts
					.Any(str => regex.Match(str).Success))
					.ToList()
				);
			}

			return result;
		}
	}
}