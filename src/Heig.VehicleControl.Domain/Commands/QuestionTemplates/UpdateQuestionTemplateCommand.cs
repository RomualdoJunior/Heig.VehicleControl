using Heig.VehicleControl.Domain.Commands.QuestionTemplates.Validation;

namespace Heig.VehicleControl.Domain.Commands.QuestionTemplates
{
    public class UpdateQuestionTemplateCommand : QuestionTemplateCommand
    {
        public UpdateQuestionTemplateCommand(Guid id, string title, string fullDescription, Guid checklistTemplateId)
        {
            Id = id;
            Title = title;
            FullDescription = fullDescription;
            ChecklistTemplateId = checklistTemplateId;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateQuestionTemplateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}