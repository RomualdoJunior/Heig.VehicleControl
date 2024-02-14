using AutoMapper;
using Heig.VehicleControl.Application.ViewModels;
using Heig.VehicleControl.Domain.Commands.QuestionTemplates;
using Heig.VehicleControl.Domain.Commands.Vehicles;

namespace Heig.VehicleControl.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<VehicleViewModel, RegisterNewVehicleCommand>()
                .ConstructUsing(c => new RegisterNewVehicleCommand(c.Description, c.LicensePlate));

            CreateMap<QuestionTemplateViewModel, RegisterNewQuestionTemplateCommand>()
                .ConstructUsing(c => new RegisterNewQuestionTemplateCommand(c.Title, c.FullDescription, c.ChecklistTemplateId));
        }
    }
}