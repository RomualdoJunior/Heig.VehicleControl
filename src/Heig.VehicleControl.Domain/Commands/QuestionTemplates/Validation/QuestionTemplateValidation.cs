using FluentValidation;
using Heig.VehicleControl.Domain.Commands.QuestionTemplates;

namespace Heig.VehicleControl.Domain.Commands.QuestionTemplates.Validation
{
    public abstract class QuestionTemplateValidation<T> : AbstractValidator<T> where T : QuestionTemplateCommand
    {
        protected void ValidateTitle()
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Please ensure you have entered the Title")
                .MaximumLength(100).WithMessage("The Title max character is 100");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}