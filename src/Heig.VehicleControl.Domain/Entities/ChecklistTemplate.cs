using Heig.VehicleControl.Domain.Common;

namespace Heig.VehicleControl.Domain.Entities
{
    public class ChecklistTemplate : BaseEntity
    {
        public string Title { get; set; }
        public List<QuestionTemplate> Questions { get; private set; }

        public virtual ICollection<Checklist> Checklists { get; set; }
    }
}