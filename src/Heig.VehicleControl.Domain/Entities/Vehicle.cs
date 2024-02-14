using Heig.VehicleControl.Domain.Common;

namespace Heig.VehicleControl.Domain.Entities
{
    public class Vehicle : BaseEntity, IAggregateRoot
    {
        public Vehicle(string description, string licensePlate)
        {
            Description = description;
            LicensePlate = licensePlate;
        }

        public string Description { get; private set; }
        public string LicensePlate { get; private set; }

        public ICollection<Checklist> Checklists { get; set; }

        internal void Update(string licensePlate, string description)
        {
            UpdatedOn = DateTime.Now;
            LicensePlate = licensePlate;
            Description = description;
        }
    }
}