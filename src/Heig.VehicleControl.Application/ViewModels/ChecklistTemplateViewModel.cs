using Heig.VehicleControl.Domain.Entities;

namespace Heig.VehicleControl.Application.ViewModels
{
    public class ChecklistTemplateViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public List<QuestionTemplateViewModel>? Questions { get; set; }
    }
}