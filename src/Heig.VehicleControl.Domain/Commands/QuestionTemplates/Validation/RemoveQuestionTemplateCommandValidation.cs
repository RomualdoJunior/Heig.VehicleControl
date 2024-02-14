namespace Heig.VehicleControl.Domain.Commands.QuestionTemplates.Validation
{
    public class RemoveQuestionTemplateCommandValidation : QuestionTemplateValidation<RemoveQuestionTemplateCommand>
    {
        public RemoveQuestionTemplateCommandValidation()
        {
            ValidateId();
        }
    }
}