using AutoMapper;
using FluentValidation.Results;
using Heig.VehicleControl.Application.Interfaces;
using Heig.VehicleControl.Application.ViewModels;
using Heig.VehicleControl.Domain.Commands.QuestionTemplates;
using Heig.VehicleControl.Domain.Interfaces.Repositories;
using MediatR;

namespace Heig.VehicleControl.Application.Services
{
    internal class QuestionTemplateAppService : IQuestionTemplateAppService
    {
        private readonly IMapper _mapper;
        private readonly IQuestionTemplateRepository _questionTemplateRepository;
        private readonly IMediator _mediator;

        public QuestionTemplateAppService(IMapper mapper, IQuestionTemplateRepository questionTemplateRepository, IMediator mediator)
        {
            _mapper = mapper;
            _questionTemplateRepository = questionTemplateRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<QuestionTemplateViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<QuestionTemplateViewModel>>(await _questionTemplateRepository.GetAll());
        }

        public async Task<QuestionTemplateViewModel> GetById(Guid id)
        {
            return _mapper.Map<QuestionTemplateViewModel>(await _questionTemplateRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(QuestionTemplateViewModel questionTemplateViewModel)
        {
            var registerCommand = new RegisterNewQuestionTemplateCommand(questionTemplateViewModel.Title, questionTemplateViewModel.FullDescription, questionTemplateViewModel.ChecklistTemplateId);
            return await _mediator.Send(registerCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveQuestionTemplateCommand(id);
            return await _mediator.Send(removeCommand);
        }

        public async Task<ValidationResult> Update(QuestionTemplateViewModel questionTemplateViewModel)
        {
            var updateCommand = new UpdateQuestionTemplateCommand(questionTemplateViewModel.Id, questionTemplateViewModel.Title, questionTemplateViewModel.FullDescription, questionTemplateViewModel.ChecklistTemplateId);
            return await _mediator.Send(updateCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}