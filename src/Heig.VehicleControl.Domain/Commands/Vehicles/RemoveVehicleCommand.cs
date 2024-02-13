using Heig.VehicleControl.Domain.Commands.Vehicles.Validation;

namespace Heig.VehicleControl.Domain.Commands.Vehicles
{
    public class RemoveVehicleCommand : VehicleCommand
    {
        public RemoveVehicleCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveVehicleCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}