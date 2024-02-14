namespace Heig.VehicleControl.Domain.Commands.ChecklistTemplates.Validation
{
    public class UpdateChecklistTemplateCommandValidation : ChecklistTemplateValidation<UpdateChecklistTemplateCommand>
    {
        public UpdateChecklistTemplateCommandValidation()
        {
            ValidateTitle();
        }
    }
}