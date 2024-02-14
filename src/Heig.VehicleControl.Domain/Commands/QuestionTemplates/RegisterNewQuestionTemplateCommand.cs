using Heig.VehicleControl.Domain.Commands.QuestionTemplates.Validation;
using Heig.VehicleControl.Domain.Commands.Vehicles.Validation;
using System.ComponentModel.DataAnnotations;

namespace Heig.VehicleControl.Domain.Commands.QuestionTemplates

{
    public class RegisterNewQuestionTemplateCommand : QuestionTemplateCommand
    {
        public RegisterNewQuestionTemplateCommand(string title, string fullDescription, Guid checklistTemplateId)
        {
            Title = title;
            FullDescription = fullDescription;
            ChecklistTemplateId = checklistTemplateId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewQuestionTemplateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}