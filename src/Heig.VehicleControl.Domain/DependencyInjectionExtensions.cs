using FluentValidation.Results;
using Heig.VehicleControl.Domain.Commands.QuestionTemplates;
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
            services.AddScoped<IRequestHandler<UpdateVehicleCommand, ValidationResult>, VehicleCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveVehicleCommand, ValidationResult>, VehicleCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewQuestionTemplateCommand, ValidationResult>, QuestionTemplateCommandHandler>();
        }
    }
}