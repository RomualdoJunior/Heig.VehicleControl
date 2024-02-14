using Heig.VehicleControl.Domain.Interfaces.Repositories;
using Heig.VehicleControl.Infra.Data;
using Heig.VehicleControl.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Heig.VehicleControl.Infra
{
    public static class DependencyInjectionExtensions
    {
        public static void AddInfraServices(this IServiceCollection services)
        {
            //Infra - Contexts
            services.AddScoped<VehicleControlContext>();

            // Infra - Data
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IChecklistRepository, ChecklistRepository>();
            services.AddScoped<IChecklistTemplateRepository, ChecklistTemplateRepository>();
            services.AddScoped<IQuestionTemplateRepository, QuestionTemplateRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();

        }
    }
}