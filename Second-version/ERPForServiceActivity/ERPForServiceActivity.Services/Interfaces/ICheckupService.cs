using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using ERPForServiceActivity.CommonModels.ViewModels.Checkup;

namespace ERPForServiceActivity.Services.Interfaces {
	public interface ICheckupService {
		public Task<List<TechniciаnCheckupViewModel>> 
			TechnicianCheckup(string serviceName, 
			DateTime begin, DateTime end);

		public Task<List<RepairStatusCheckupViewModel>> 
			StatusCheckup(string status, 
			DateTime begin, DateTime end);

		public Task ExoprtTechniciansCheckupToExcel(
			List<TechniciаnCheckupViewModel> results);

		public Task ExportRepairStatusCheckupToExcel(
			List<RepairStatusCheckupViewModel> results);
	}
}
