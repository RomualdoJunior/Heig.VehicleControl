using Heig.VehicleControl.Domain.Commands.QuestionTemplates.Validation;

namespace Heig.VehicleControl.Domain.Commands.QuestionTemplates
{
    public class RemoveQuestionTemplateCommand : QuestionTemplateCommand
    {
        public RemoveQuestionTemplateCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveQuestionTemplateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}