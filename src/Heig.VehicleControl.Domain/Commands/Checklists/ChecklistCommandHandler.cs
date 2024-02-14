using FluentValidation.Results;
using Heig.VehicleControl.Domain.Common;
using Heig.VehicleControl.Domain.Entities;
using Heig.VehicleControl.Domain.Interfaces.Repositories;
using MediatR;

namespace Heig.VehicleControl.Domain.Commands.Checklists
{
    public class ChecklistCommandHandler : CommandHandler,
            IRequestHandler<RegisterNewChecklistCommand, ValidationResult>,
            IRequestHandler<UpdateChecklistCommand, ValidationResult>,
            IRequestHandler<RemoveChecklistCommand, ValidationResult>
    {
        private readonly IChecklistRepository _checklistRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IChecklistTemplateRepository _checklistTemplateRepository;

        public ChecklistCommandHandler(
            IChecklistRepository checklistRepository,
            IVehicleRepository vehicleRepository,
            IChecklistTemplateRepository checklistTemplateRepository)
        {
            _checklistRepository = checklistRepository;
            _vehicleRepository = vehicleRepository;
            _checklistTemplateRepository = checklistTemplateRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewChecklistCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var vehicle = await _vehicleRepository.GetById(request.VehicleId);

            if (vehicle is null)
            {
                AddError("This vehicle doesn't exists.");
                return ValidationResult;
            }

            var checklistTemplate = await _checklistTemplateRepository.GetById(request.ChecklistTemplateId);

            if (checklistTemplate is null)
            {
                AddError("This Checklist Template doesn't exists.");
                return ValidationResult;
            }

            var checklist = Checklist.Factory.Create(vehicle, checklistTemplate);

            _checklistRepository.Add(checklist);

            return await Commit(_checklistRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateChecklistCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var checklist = await _checklistRepository.GetById(request.VehicleId);

            if (checklist is null)
            {
                AddError("This checklist doesn't exists.");
                return ValidationResult;
            }

            var vehicle = await _vehicleRepository.GetById(request.VehicleId);

            if (vehicle is null)
            {
                AddError("This vehicle doesn't exists.");
                return ValidationResult;
            }

            var checklistTemplate = await _checklistTemplateRepository.GetById(request.ChecklistTemplateId);

            if (checklistTemplate is null)
            {
                AddError("This Checklist Template doesn't exists.");
                return ValidationResult;
            }

            checklist.Update(vehicle, checklistTemplate);

            _checklistRepository.Update(checklist);

            return await Commit(_checklistRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveChecklistCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var Checklist = await _checklistRepository.GetById(request.Id);

            if (Checklist is null)
            {
                AddError("This Checklist doesn't exists.");
                return ValidationResult;
            }

            _checklistRepository.Remove(Checklist);

            return await Commit(_checklistRepository.UnitOfWork);
        }
    }
}