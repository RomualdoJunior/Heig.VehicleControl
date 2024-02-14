namespace Heig.VehicleControl.Domain.Commands.ChecklistTemplates.Validation
{
    public class RegisterNewChecklistTemplateCommandValidation : ChecklistTemplateValidation<RegisterNewChecklistTemplateCommand>
    {
        public RegisterNewChecklistTemplateCommandValidation()
        {
            ValidateTitle();
        }
    }
}