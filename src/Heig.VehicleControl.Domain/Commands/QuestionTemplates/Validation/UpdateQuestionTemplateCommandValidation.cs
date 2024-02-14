namespace Heig.VehicleControl.Domain.Commands.QuestionTemplates.Validation
{
    public class UpdateQuestionTemplateCommandValidation : QuestionTemplateValidation<UpdateQuestionTemplateCommand>
    {
        public UpdateQuestionTemplateCommandValidation()
        {
            ValidateTitle();
            ValidateChecklistTemplateId();
        }
    }
}