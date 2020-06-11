using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ERPForServiceActivity.Services.Interfaces.Repairs;
using ERPForServiceActivity.CommonModels.BindingModels.Repairs;

namespace ERPForServiceActivity.API.Controllers {
	[Authorize]
	[ApiController]
	[Route("[controller]")]
	public class RepairsController : ControllerBase {
		private IRepairService service;

		public RepairsController(IRepairService service) {
			this.service = service;
		}

		[HttpPost("add-repair")]
		public async Task<bool> UploadRepair(
			[FromBody] AddRepairBindingModel model) {

			if(!ModelState.IsValid) {
				return false;
			}

			return await service.UploadRepair(model)
				.ConfigureAwait(false);
		}
	}
}
