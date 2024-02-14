using Heig.VehicleControl.Application.Interfaces;
using Heig.VehicleControl.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Heig.VehicleControl.WebApi.Controllers
{
    //[Authorize]
    public class QuestionTemplateController : ApiController
    {
        private readonly IQuestionTemplateAppService _questionTemplateAppService;

        public QuestionTemplateController(IQuestionTemplateAppService questionTemplateAppService)
        {
            _questionTemplateAppService = questionTemplateAppService;
        }

        [HttpGet("questionTemplate")]
        public async Task<IEnumerable<QuestionTemplateViewModel>> Get()
        {
            return await _questionTemplateAppService.GetAll();
        }

        [HttpGet("questionTemplate/{id:guid}")]
        public async Task<QuestionTemplateViewModel> Get(Guid id)
        {
            return await _questionTemplateAppService.GetById(id);
        }

        [HttpPost("questionTemplate")]
        public async Task<IActionResult> Post([FromBody] QuestionTemplateViewModel vehicleViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _questionTemplateAppService.Register(vehicleViewModel));
        }

        [HttpPut("questionTemplate")]
        public async Task<IActionResult> Put([FromBody] QuestionTemplateViewModel vehicleViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _questionTemplateAppService.Update(vehicleViewModel));
        }

        [HttpDelete("questionTemplate")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _questionTemplateAppService.Remove(id));
        }
    }
}
