using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MatBlazor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ERPForServiceActivity.Services;
using ERPForServiceActivity.CommonModels.ViewModels.Repairs;
using ERPForServiceActivity.CommonModels.BindingModels.Repairs;

namespace ERPForServiceActivity.API.Controllers {
    [ApiController]
    [Route("api/repairs")]
    public class RepairsController : ControllerBase {
        private RepairService service = new RepairService();

        [HttpPost("create-repair")]
        public void AddRepair([FromBody] AddRepairBindingModel repair) {
            service.UploadRepair("Value", repair);
        }

        [HttpGet("get-repairs/{serviceName}")]
        public async Task<List<RepairViewModel>> GetAllRepairs(string serviceName) {
            return await service.GetAllRepairs(serviceName);
        }

        [HttpGet("get-last-id/{serviceName}")]
        public async Task<int> GetLastId(string serviceName) {
            return await Task.Run(() => {
                return service.GetLastId(serviceName).Result;
            });
        }

        [HttpPost("get-data")]
        public ResultFromOCRBindingModel GetData(
            [FromBody] AddRepairBindingModel model) {

            ResultFromOCRBindingModel data =
                new ResultFromOCRBindingModel() {
                    ApplianceBrand = model.ApplianceBrand,
                    ApplianceType = model.ApplianceType
                };

            return null;//service.GetData(data);
        }
    }
}