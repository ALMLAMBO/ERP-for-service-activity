using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ERPForServiceActivity.Services;
using ERPForServiceActivity.Models.Repairs;

namespace ERPForServiceActivity.API.Controllers {
    [ApiController]
    [Route("api/log")]
    public class LogController : ControllerBase {
        private LogService service = new LogService();

        [HttpGet("get-all-logs/{id}")]
        public async Task<List<RepairLog>> GetLogsForRepair(int id) {
            return await service.GetLogsForRepair(id);
        }

        [HttpPost("add-log")]
        public async void AddLog([FromBody] RepairLog log) {
            await service.UploadLog(log);
        }

        [HttpPost("add-log-to-ex-repair")]
        public async void AddLogToExistingRepair([FromBody] RepairLog log) {
            await service.UploadLogToExistingRepair(log.RepairId, log);
        }
    }
}