namespace Heig.VehicleControl.Domain.Commands.ChecklistTemplates.Validation
{
    public class RemoveChecklistTemplateCommandValidation : ChecklistTemplateValidation<RemoveChecklistTemplateCommand>
    {
        public RemoveChecklistTemplateCommandValidation()
        {
            ValidateId();
        }
    }
}