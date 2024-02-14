using Heig.VehicleControl.Domain.Entities;

namespace Heig.VehicleControl.Application.ViewModels
{
    public class QuestionTemplateViewModel
    {
        public Guid Id { get; private set; }
        public string Title { get; set; }
        public string FullDescription { get; set; }
        public Guid ChecklistTemplateId  { get; set; }
    }
}