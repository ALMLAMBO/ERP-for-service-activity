using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ERPForServiceActivity.CommonModels.BindingModels.Repairs;
using ERPForServiceActivity.Services;

namespace ERPForServiceActivity.API.Controllers {
    [ApiController]
    [Route("api/repairs")]
    public class RepairsController : ControllerBase {
        private RepairService service = new RepairService();

        [HttpPost("create-repair")]
        public void AddRepair([FromBody] AddRepairBindingModel repair) {
            service.UploadRepair("Value", repair);
        }
    }
}