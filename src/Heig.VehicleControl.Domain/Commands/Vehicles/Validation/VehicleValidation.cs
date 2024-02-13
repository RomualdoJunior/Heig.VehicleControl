using FluentValidation;

namespace Heig.VehicleControl.Domain.Commands.Vehicles.Validation
{
    public abstract class VehicleValidation<T> : AbstractValidator<T> where T : VehicleCommand
    {
        protected void ValidateLicensePlate()
        {
            RuleFor(c => c.LicensePlate)
                .NotEmpty().WithMessage("Please ensure you have entered the License Plate")
                .Length(7).WithMessage("The License Plate must have 7 characters");
        }
    }
}