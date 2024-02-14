using Heig.VehicleControl.Domain.Commands.ChecklistTemplates.Validation;

namespace Heig.VehicleControl.Domain.Commands.ChecklistTemplates
{
    public class UpdateChecklistTemplateCommand : ChecklistTemplateCommand
    {
        public UpdateChecklistTemplateCommand(string title)
        {
            Title = title;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateChecklistTemplateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}