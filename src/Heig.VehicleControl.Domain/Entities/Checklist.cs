using Heig.VehicleControl.Domain.Common;

namespace Heig.VehicleControl.Domain.Entities
{
    public class Checklist : BaseEntity
    {
        public Vehicle Vehicle { get; private set; }
        public ChecklistTemplate OriginalChecklistTemplate { get; private set; }
        public List<Answer> Answers { get; private set; }
    }
}