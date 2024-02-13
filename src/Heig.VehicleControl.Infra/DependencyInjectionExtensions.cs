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
            // Infra - Data
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<VehicleControlContext>();
        }
    }
}