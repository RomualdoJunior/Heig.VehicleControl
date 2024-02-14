using Heig.VehicleControl.Domain.Commands.ChecklistTemplates.Validation;

namespace Heig.VehicleControl.Domain.Commands.ChecklistTemplates
{
    public class RemoveChecklistTemplateCommand : ChecklistTemplateCommand
    {
        public RemoveChecklistTemplateCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveChecklistTemplateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}