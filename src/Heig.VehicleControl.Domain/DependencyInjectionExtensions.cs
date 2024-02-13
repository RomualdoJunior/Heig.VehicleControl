using FluentValidation.Results;
using Heig.VehicleControl.Domain.Commands.Vehicles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Heig.VehicleControl.Domain
{
    public static class DependencyInjectionExtensions
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewVehicleCommand, ValidationResult>, VehicleCommandHandler>();
        }
    }
}