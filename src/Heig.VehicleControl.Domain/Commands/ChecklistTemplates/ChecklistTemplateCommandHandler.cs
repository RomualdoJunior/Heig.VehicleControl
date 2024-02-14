using FluentValidation.Results;
using Heig.VehicleControl.Domain.Common;
using Heig.VehicleControl.Domain.Entities;
using Heig.VehicleControl.Domain.Interfaces.Repositories;
using MediatR;

namespace Heig.VehicleControl.Domain.Commands.ChecklistTemplates
{
    public class ChecklistTemplateCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewChecklistTemplateCommand, ValidationResult>,
        IRequestHandler<UpdateChecklistTemplateCommand, ValidationResult>,
        IRequestHandler<RemoveChecklistTemplateCommand, ValidationResult>
    {
        private readonly IChecklistTemplateRepository _ChecklistTemplateRepository;

        public ChecklistTemplateCommandHandler(IChecklistTemplateRepository ChecklistTemplateRepository)
        {
            _ChecklistTemplateRepository = ChecklistTemplateRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewChecklistTemplateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var ChecklistTemplate = new ChecklistTemplate(request.Title);

            ChecklistTemplate.AddQuestionsTemplate(request.Questions);

            _ChecklistTemplateRepository.Add(ChecklistTemplate);

            return await Commit(_ChecklistTemplateRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateChecklistTemplateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var ChecklistTemplate = await _ChecklistTemplateRepository.GetById(request.Id);

            ChecklistTemplate.Update(request.Title);

            _ChecklistTemplateRepository.Update(ChecklistTemplate);

            return await Commit(_ChecklistTemplateRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveChecklistTemplateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var ChecklistTemplate = await _ChecklistTemplateRepository.GetById(request.Id);

            if (ChecklistTemplate is null)
            {
                AddError("This Checklist Template doesn't exists.");
                return ValidationResult;
            }

            _ChecklistTemplateRepository.Remove(ChecklistTemplate);

            return await Commit(_ChecklistTemplateRepository.UnitOfWork);
        }
    }
}