namespace Heig.VehicleControl.Domain.Commands.Vehicles.Validation
{
    public class UpdateVehicleCommandValidation : VehicleValidation<UpdateVehicleCommand>
    {
        public UpdateVehicleCommandValidation()
        {
            ValidateId();
            ValidateLicensePlate();
        }
    }
}