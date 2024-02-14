using FluentValidation.Results;
using Heig.VehicleControl.Domain.Commands.QuestionTemplates;
using Heig.VehicleControl.Domain.Commands.Vehicles;
using Heig.VehicleControl.Domain.Commands.Checklists;
using Heig.VehicleControl.Domain.Commands.ChecklistTemplates;
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
            services.AddScoped<IRequestHandler<UpdateQuestionTemplateCommand, ValidationResult>, QuestionTemplateCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveQuestionTemplateCommand, ValidationResult>, QuestionTemplateCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewChecklistCommand, ValidationResult>, ChecklistCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateChecklistCommand, ValidationResult>, ChecklistCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveChecklistCommand, ValidationResult>, ChecklistCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewChecklistTemplateCommand, ValidationResult>, ChecklistTemplateCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateChecklistTemplateCommand, ValidationResult>, ChecklistTemplateCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveChecklistTemplateCommand, ValidationResult>, ChecklistTemplateCommandHandler>();
        }
    }
}