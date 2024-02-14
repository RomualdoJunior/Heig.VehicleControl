using Heig.VehicleControl.Application.Interfaces;
using Heig.VehicleControl.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Heig.VehicleControl.WebApi.Controllers
{
    //[Authorize]
    public class ChecklistController : ApiController
    {
        private readonly IChecklistAppService _ChecklistAppService;

        public ChecklistController(IChecklistAppService ChecklistAppService)
        {
            _ChecklistAppService = ChecklistAppService;
        }

        [HttpGet("Checklist")]
        public async Task<IEnumerable<ChecklistViewModel>> Get()
        {
            return await _ChecklistAppService.GetAll();
        }

        [HttpGet("Checklist/{id:guid}")]
        public async Task<ChecklistViewModel> Get(Guid id)
        {
            return await _ChecklistAppService.GetById(id);
        }

        [HttpPost("Checklist")]
        public async Task<IActionResult> Post([FromBody] ChecklistViewModel ChecklistViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _ChecklistAppService.Register(ChecklistViewModel));
        }

        [HttpPut("Checklist")]
        public async Task<IActionResult> Put([FromBody] ChecklistViewModel ChecklistViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _ChecklistAppService.Update(ChecklistViewModel));
        }

        [HttpDelete("Checklist")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _ChecklistAppService.Remove(id));
        }
    }
}
