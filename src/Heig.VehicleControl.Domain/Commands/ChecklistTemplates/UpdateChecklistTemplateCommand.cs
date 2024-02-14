using Heig.VehicleControl.Domain.Commands.ChecklistTemplates.Validation;

namespace Heig.VehicleControl.Domain.Commands.ChecklistTemplates
{
    public class UpdateChecklistTemplateCommand : ChecklistTemplateCommand
    {
        public UpdateChecklistTemplateCommand(Guid id, string title)
        {
            Id = id;
            Title = title;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateChecklistTemplateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}