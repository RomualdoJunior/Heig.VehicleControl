using FluentValidation.Results;
using Heig.VehicleControl.Domain.Common;

namespace Heig.VehicleControl.Domain.Entities
{
    public class Checklist : BaseEntity, IAggregateRoot
    {
        protected Checklist()
        {
            Answers = new List<Answer> { };
        }

        public Checklist(Vehicle vehicle, ChecklistTemplate originalChecklistTemplate)
        {
            Vehicle = vehicle;
            OriginalChecklistTemplate = originalChecklistTemplate;
        }

        public Vehicle Vehicle { get; private set; }
        public ChecklistTemplate OriginalChecklistTemplate { get; private set; }
        public List<Answer> Answers { get; private set; }

        public static class Factory
        {
            public static Checklist Create(Vehicle vehicle, ChecklistTemplate checklistTemplate)
            {
                var checklist = new Checklist() { };
                if (checklistTemplate.Questions == null)
                {
                    checklist.ValidationResult.Errors.Add(new ValidationFailure(string.Empty, "Template without Questions."));
                    return checklist;
                };

                checklist.Vehicle = vehicle;
                checklist.OriginalChecklistTemplate = checklistTemplate;

                foreach (var question in checklistTemplate.Questions)
                {
                    var answer = new Answer(question.Title);
                    checklist.Answers.Add(answer);
                }

                return checklist;
            }
        }

        internal void Update(Vehicle vehicle, ChecklistTemplate checklistTemplate)
        {
            UpdatedOn = DateTime.Now;
            Vehicle = vehicle;
            OriginalChecklistTemplate = checklistTemplate;
            Answers.Clear();
            foreach (var question in checklistTemplate.Questions)
            {
                var answer = new Answer(question.Title);
                Answers.Add(answer);
            }
        }
    }
}