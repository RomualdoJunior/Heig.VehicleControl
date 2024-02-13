namespace Heig.VehicleControl.Domain.Commands.Vehicles.Validation
{
    public class RemoveVehicleCommandValidation : VehicleValidation<RemoveVehicleCommand>
    {
        public RemoveVehicleCommandValidation()
        {
            ValidateId();
        }
    }
}