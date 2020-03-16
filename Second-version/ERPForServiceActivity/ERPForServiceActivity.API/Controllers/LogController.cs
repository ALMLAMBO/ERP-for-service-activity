using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ERPForServiceActivity.Services;
using ERPForServiceActivity.Models.Repairs;
using ERPForServiceActivity.CommonModels.ViewModels.Repairs;

namespace ERPForServiceActivity.API.Controllers {
    [ApiController]
    [Route("api/log")]
    public class LogController : ControllerBase {
        private LogService service = new LogService();

        [HttpGet("get-all-logs/{id}")]
        public List<RepairLog> GetLogsForRepair(int id) {
            return service.GetLogsForRepair(id);
        }

        [HttpPost("add-log")]
        public async void AddLog([FromBody] RepairLog log) {
            await service.UploadLog(log);
        }

        [HttpPost("add-log-to-ex-repair")]
        public async void AddLogToExistingRepair([FromBody] RepairLog log) {
            await service.UploadLogToExistingRepair(log.RepairId, log);
        }

        [HttpPut("update-repair")]
        public void UpdateRepair([FromBody] RepairViewModel model) {
            RepairService repairService = new RepairService();
            repairService.UpdateRepair(model);
        }
    }
}