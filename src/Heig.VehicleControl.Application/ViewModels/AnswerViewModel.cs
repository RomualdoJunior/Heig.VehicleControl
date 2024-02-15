namespace Heig.VehicleControl.Application.ViewModels
{
    public class AnswerViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? AdditionalObservation { get; set; }
        public bool Ok { get; set; }
    }
}