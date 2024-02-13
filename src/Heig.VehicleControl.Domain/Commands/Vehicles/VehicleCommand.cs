using Heig.VehicleControl.Domain.Common;

namespace Heig.VehicleControl.Domain.Commands.Vehicles
{
    public abstract class VehicleCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Description { get; protected set; }
        public string LicensePlate { get; protected set; }
    }
}