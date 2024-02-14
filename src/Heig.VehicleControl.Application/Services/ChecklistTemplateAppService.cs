using AutoMapper;
using FluentValidation.Results;
using Heig.VehicleControl.Application.Interfaces;
using Heig.VehicleControl.Application.ViewModels;
using Heig.VehicleControl.Domain.Commands.ChecklistTemplates;
using Heig.VehicleControl.Domain.Entities;
using Heig.VehicleControl.Domain.Interfaces.Repositories;
using MediatR;

namespace Heig.VehicleControl.Application.Services
{
    internal class ChecklistTemplateAppService : IChecklistTemplateAppService
    {
        private readonly IMapper _mapper;
        private readonly IChecklistTemplateRepository _ChecklistTemplateRepository;
        private readonly IMediator _mediator;

        public ChecklistTemplateAppService(IMapper mapper, IChecklistTemplateRepository ChecklistTemplateRepository, IMediator mediator)
        {
            _mapper = mapper;
            _ChecklistTemplateRepository = ChecklistTemplateRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ChecklistTemplateViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ChecklistTemplateViewModel>>(await _ChecklistTemplateRepository.GetAll());
        }

        public async Task<ChecklistTemplateViewModel> GetById(Guid id)
        {
            return _mapper.Map<ChecklistTemplateViewModel>(await _ChecklistTemplateRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(ChecklistTemplateViewModel vehicleViewModel)
        {
            var questions = new List<QuestionTemplate>();
            vehicleViewModel.Questions.ForEach(question =>
            {
                var questionTemplate = new QuestionTemplate(question.Title, question.FullDescription);
                questions.Add(questionTemplate);
            });
            var registerCommand = new RegisterNewChecklistTemplateCommand(vehicleViewModel.Title, questions);
            return await _mediator.Send(registerCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveChecklistTemplateCommand(id);
            return await _mediator.Send(removeCommand);
        }

        public async Task<ValidationResult> Update(ChecklistTemplateViewModel vehicleViewModel)
        {
            var updateCommand = _mapper.Map<UpdateChecklistTemplateCommand>(vehicleViewModel);
            return await _mediator.Send(updateCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}