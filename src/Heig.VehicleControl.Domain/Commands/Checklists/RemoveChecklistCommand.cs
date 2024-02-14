using Heig.VehicleControl.Domain.Commands.ChecklistTemplates.Validation;
using Heig.VehicleControl.Domain.Commands.ChecklistTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heig.VehicleControl.Domain.Commands.Checklists.Validation;

namespace Heig.VehicleControl.Domain.Commands.Checklists
{
    public class RemoveChecklistCommand : ChecklistCommand
    {
        public RemoveChecklistCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveChecklistCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
