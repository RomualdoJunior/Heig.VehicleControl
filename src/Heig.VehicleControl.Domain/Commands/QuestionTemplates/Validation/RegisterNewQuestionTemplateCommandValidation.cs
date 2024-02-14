namespace Heig.VehicleControl.Domain.Commands.QuestionTemplates.Validation
{
    public class RegisterNewQuestionTemplateCommandValidation : QuestionTemplateValidation<RegisterNewQuestionTemplateCommand>
    {
        public RegisterNewQuestionTemplateCommandValidation()
        {
            ValidateTitle();
            ValidateChecklistTemplateId();
        }
    }
}