using Heig.VehicleControl.Domain.Commands.Vehicles.Validation;
using System.ComponentModel.DataAnnotations;

namespace Heig.VehicleControl.Domain.Commands.Vehicles
{
    public class RegisterNewVehicleCommand : VehicleCommand
    {
        public RegisterNewVehicleCommand(string description, string licensePlate)
        {
            Description = description;
            LicensePlate = licensePlate;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewVehicleCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}