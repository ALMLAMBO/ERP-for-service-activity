using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using ERPForServiceActivity.Models.Repairs;

namespace ERPForServiceActivity.Services.Interfaces {
	public interface ILogService {
		Task UploadLog(RepairLog log);

		List<RepairLog> GetLogsForRepair(int id);

		Task UploadLogToExistingRepair(int id, RepairLog log);
	}
}
