using Heig.VehicleControl.Domain.Common;

namespace Heig.VehicleControl.Domain.Entities
{
    public class ChecklistTemplate : BaseEntity, IAggregateRoot
    {
        public ChecklistTemplate(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
        public List<QuestionTemplate> Questions { get; private set; }

        public virtual ICollection<Checklist> Checklists { get; set; }

        internal void AddQuestionsTemplate(List<QuestionTemplate>? questions)
        {
            if (questions == null) return;

            Questions = questions;
        }

        internal void Update(string title)
        {
            UpdatedOn = DateTime.Now;
            Title = title;
        }
    }
}