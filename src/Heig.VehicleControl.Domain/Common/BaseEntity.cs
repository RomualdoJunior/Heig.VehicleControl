using System.ComponentModel.DataAnnotations;

namespace Heig.VehicleControl.Domain.Common
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.Now;
            UpdatedOn = null;
        }

        public Guid Id { get; protected set; }
        public DateTime? CreatedOn { get; protected set; }
        public DateTime? UpdatedOn { get; protected set; }

        public ValidationResult ValidationResult { get; private set; }
    }
}