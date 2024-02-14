using Heig.VehicleControl.Domain.Common;

namespace Heig.VehicleControl.Domain.Entities
{
    public class QuestionTemplate : BaseEntity, IAggregateRoot
    {
        public QuestionTemplate(string title, string fullDescription)
        {
            Title = title;
            FullDescription = fullDescription;
        }

        public string Title { get; private set; }
        public string FullDescription { get; private set; }

        public virtual ChecklistTemplate ChecklistTemplate { get; set; }

        internal void AddCheckListTemplate(ChecklistTemplate checklistTemplate)
        {
            ChecklistTemplate = checklistTemplate;
        }
    }
}