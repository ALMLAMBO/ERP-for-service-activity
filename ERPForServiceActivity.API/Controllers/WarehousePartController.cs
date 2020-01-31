using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ERPForServiceActivity.Services;
using ERPForServiceActivity.CommonModels.ViewModels.Warehouse;
using ERPForServiceActivity.CommonModels.BindingModels.WarehouseParts;

namespace ERPForServiceActivity.API.Controllers {
    [Route("api/warehouse-parts")]
    [ApiController]
    public class WarehousePartController : ControllerBase {
        private WarehousePartService service = 
            new WarehousePartService();

        [HttpGet("get-parts/{serviceName}")]
        public async Task<List<WarehousePartViewModel>> 
            GetWarehouseParts(string serviceName) {

            return await service.GetAllParts(serviceName);
        }

        [HttpPost("add-part/{serviceName}")]
        public void AddPart(
            [FromBody] AddWarehousePartBindingModel newPart, 
            string serviceName) {

            service.AddWarehousePart(newPart, serviceName);
        }
    }
}