using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using ERPForServiceActivity.Models.Repairs;

namespace ERPForServiceActivity.Services.Interfaces {
	public interface ILogService {
		Task UploadLog(RepairLog log);

		Task<List<RepairLog>> GetLogsForRepair(int id);
	}
}
