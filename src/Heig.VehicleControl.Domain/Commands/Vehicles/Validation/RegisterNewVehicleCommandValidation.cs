namespace Heig.VehicleControl.Domain.Commands.Vehicles.Validation
{
    public class RegisterNewVehicleCommandValidation : VehicleValidation<RegisterNewVehicleCommand>
    {
        public RegisterNewVehicleCommandValidation()
        {
            ValidateLicensePlate();
        }
    }
}