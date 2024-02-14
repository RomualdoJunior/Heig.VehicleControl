using AutoMapper;
using Heig.VehicleControl.Application.ViewModels;
using Heig.VehicleControl.Domain.Entities;

namespace Heig.VehicleControl.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Vehicle, VehicleViewModel>();
            CreateMap<Checklist, ChecklistViewModel>();
            CreateMap<ChecklistTemplate, ChecklistTemplateViewModel>();
            CreateMap<QuestionTemplate, QuestionTemplateViewModel>();
            CreateMap<Answer, AnswerViewModel> ();
        }
    }
}