using Heig.VehicleControl.Domain.Common;
using Heig.VehicleControl.Domain.Entities;

namespace Heig.VehicleControl.Domain.Commands.ChecklistTemplates
{
    public abstract class ChecklistTemplateCommand : Command
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<QuestionTemplate>? Questions { get; set; }
    }
}