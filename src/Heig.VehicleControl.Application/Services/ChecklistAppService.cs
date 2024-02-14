using AutoMapper;
using FluentValidation.Results;
using Heig.VehicleControl.Application.Interfaces;
using Heig.VehicleControl.Application.ViewModels;
using Heig.VehicleControl.Domain.Commands.Checklists;
using Heig.VehicleControl.Domain.Entities;
using Heig.VehicleControl.Domain.Interfaces.Repositories;
using MediatR;

namespace Heig.VehicleControl.Application.Services
{
    internal class ChecklistAppService : IChecklistAppService
    {
        private readonly IMapper _mapper;
        private readonly IChecklistRepository _ChecklistRepository;
        private readonly IMediator _mediator;

        public ChecklistAppService(IMapper mapper, IChecklistRepository ChecklistRepository, IMediator mediator)
        {
            _mapper = mapper;
            _ChecklistRepository = ChecklistRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ChecklistViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ChecklistViewModel>>(await _ChecklistRepository.GetAll());
        }

        public async Task<ChecklistViewModel> GetById(Guid id)
        {
            return _mapper.Map<ChecklistViewModel>(await _ChecklistRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(ChecklistViewModel checklistViewModel)
        {
            var registerCommand = new RegisterNewChecklistCommand(checklistViewModel.VehicleId, checklistViewModel.ChecklistTemplateId);
            return await _mediator.Send(registerCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveChecklistCommand(id);
            return await _mediator.Send(removeCommand);
        }

        public async Task<ValidationResult> Update(ChecklistViewModel checklistViewModel)
        {
            var updateCommand = new UpdateChecklistCommand(checklistViewModel.VehicleId, checklistViewModel.ChecklistTemplateId);
            return await _mediator.Send(updateCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}