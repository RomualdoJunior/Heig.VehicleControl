using FluentValidation;

namespace Heig.VehicleControl.Domain.Commands.ChecklistTemplates.Validation
{
    public abstract class ChecklistTemplateValidation<T> : AbstractValidator<T> where T : ChecklistTemplateCommand
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