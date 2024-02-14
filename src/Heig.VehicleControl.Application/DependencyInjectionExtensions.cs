using Heig.VehicleControl.Application.Interfaces;
using Heig.VehicleControl.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Heig.VehicleControl.Application
{
    public static class DependencyInjectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // Application
            services.AddScoped<IVehicleAppService, VehicleAppService>();
            services.AddScoped<IChecklistAppService, ChecklistAppService>();
            services.AddScoped<IQuestionTemplateAppService, QuestionTemplateAppService>();
            services.AddScoped<IChecklistTemplateAppService, ChecklistTemplateAppService>();
        }
    }
}