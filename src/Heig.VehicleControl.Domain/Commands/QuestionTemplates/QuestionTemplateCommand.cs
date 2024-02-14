using Heig.VehicleControl.Domain.Common;

namespace Heig.VehicleControl.Domain.Commands.QuestionTemplates
{
    public abstract class QuestionTemplateCommand : Command
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string FullDescription { get; set; }
        public Guid ChecklistTemplateId { get; set; }
    }
}