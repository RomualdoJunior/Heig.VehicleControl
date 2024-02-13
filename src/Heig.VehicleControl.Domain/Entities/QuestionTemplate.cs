using Heig.VehicleControl.Domain.Common;

namespace Heig.VehicleControl.Domain.Entities
{
    public class QuestionTemplate : BaseEntity
    {
        public string Title { get; private set; }
        public string FullDescription { get; private set; }

        public virtual ChecklistTemplate ChecklistTemplate { get; set; }

    }
}