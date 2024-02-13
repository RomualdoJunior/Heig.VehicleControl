using Heig.VehicleControl.Application.Interfaces;
using Heig.VehicleControl.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Heig.VehicleControl.WebApi.Controllers
{
    //[Authorize]
    public class VehicleController : ApiController
    {
        private readonly IVehicleAppService _vehicleAppService;

        public VehicleController(IVehicleAppService vehicleAppService)
        {
            _vehicleAppService = vehicleAppService;
        }

        [HttpGet("vehicle")]
        public async Task<IEnumerable<VehicleViewModel>> Get()
        {
            return await _vehicleAppService.GetAll();
        }

        [HttpGet("vehicle/{id:guid}")]
        public async Task<VehicleViewModel> Get(Guid id)
        {
            return await _vehicleAppService.GetById(id);
        }

        [HttpPost("vehicle")]
        public async Task<IActionResult> Post([FromBody] VehicleViewModel vehicleViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _vehicleAppService.Register(vehicleViewModel));
        }

        [HttpPut("vehicle")]
        public async Task<IActionResult> Put([FromBody] VehicleViewModel vehicleViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _vehicleAppService.Update(vehicleViewModel));
        }

        [HttpDelete("vehicle")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _vehicleAppService.Remove(id));
        }
    }
}
