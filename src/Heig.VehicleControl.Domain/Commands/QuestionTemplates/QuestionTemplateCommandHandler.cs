using FluentValidation.Results;
using Heig.VehicleControl.Domain.Commands.Vehicles;
using Heig.VehicleControl.Domain.Common;
using Heig.VehicleControl.Domain.Entities;
using Heig.VehicleControl.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heig.VehicleControl.Domain.Commands.QuestionTemplates
{
    public class QuestionTemplateCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewQuestionTemplateCommand, ValidationResult>
    {
        private readonly IQuestionTemplateRepository _questionTemplateRepository;
        private readonly IChecklistTemplateRepository _checklistTemplateRepository;

        public QuestionTemplateCommandHandler(IQuestionTemplateRepository questionTemplateRepository, IChecklistTemplateRepository checklistTemplateRepository)
        {
            _questionTemplateRepository = questionTemplateRepository;
            _checklistTemplateRepository = checklistTemplateRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewQuestionTemplateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var questionTemplate = new QuestionTemplate(request.Title, request.FullDescription);
            var checklistTemplate = await _checklistTemplateRepository.GetById(questionTemplate.Id);

            if (checklistTemplate == null)
            {
                AddError("Invalid Checklist Template Id.");
                return ValidationResult;
            }

            questionTemplate.AddCheckListTemplate(checklistTemplate);

            _questionTemplateRepository.Add(questionTemplate);

            return await Commit(_questionTemplateRepository.UnitOfWork);
        }
    }
}
