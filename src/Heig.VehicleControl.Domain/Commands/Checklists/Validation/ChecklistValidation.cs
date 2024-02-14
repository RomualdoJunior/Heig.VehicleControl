using FluentValidation;
using Heig.VehicleControl.Domain.Commands.ChecklistTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heig.VehicleControl.Domain.Commands.Checklists.Validation
{
    public abstract class ChecklistValidation<T> : AbstractValidator<T> where T : ChecklistCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateVehicleId()
        {
            RuleFor(c => c.VehicleId)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateChecklistTemplateId()
        {
            RuleFor(c => c.ChecklistTemplateId)
                .NotEqual(Guid.Empty);
        }
    }
}
