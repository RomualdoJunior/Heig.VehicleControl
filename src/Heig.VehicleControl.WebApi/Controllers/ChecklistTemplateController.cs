using Heig.VehicleControl.Application.Interfaces;
using Heig.VehicleControl.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Heig.VehicleControl.WebApi.Controllers
{
    //[Authorize]
    public class ChecklistTemplateController : ApiController
    {
        private readonly IChecklistTemplateAppService _ChecklistTemplateAppService;

        public ChecklistTemplateController(IChecklistTemplateAppService ChecklistTemplateAppService)
        {
            _ChecklistTemplateAppService = ChecklistTemplateAppService;
        }

        [HttpGet("ChecklistTemplate")]
        public async Task<IEnumerable<ChecklistTemplateViewModel>> Get()
        {
            return await _ChecklistTemplateAppService.GetAll();
        }

        [HttpGet("ChecklistTemplate/{id:guid}")]
        public async Task<ChecklistTemplateViewModel> Get(Guid id)
        {
            return await _ChecklistTemplateAppService.GetById(id);
        }

        [HttpPost("ChecklistTemplate")]
        public async Task<IActionResult> Post([FromBody] ChecklistTemplateViewModel vehicleViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _ChecklistTemplateAppService.Register(vehicleViewModel));
        }

        [HttpPut("ChecklistTemplate")]
        public async Task<IActionResult> Put([FromBody] ChecklistTemplateViewModel vehicleViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _ChecklistTemplateAppService.Update(vehicleViewModel));
        }

        [HttpDelete("ChecklistTemplate")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _ChecklistTemplateAppService.Remove(id));
        }
    }
}
