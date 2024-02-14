using Heig.VehicleControl.Domain.Commands.ChecklistTemplates.Validation;
using Heig.VehicleControl.Domain.Commands.ChecklistTemplates;
using Heig.VehicleControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heig.VehicleControl.Domain.Commands.Checklists.Validation;

namespace Heig.VehicleControl.Domain.Commands.Checklists
{

    public class UpdateChecklistCommand : ChecklistCommand
    {
        public UpdateChecklistCommand(Guid vehicleId, Guid checklistTemplateId)
        {
            VehicleId = vehicleId;
            ChecklistTemplateId = checklistTemplateId;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateChecklistCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


    }
}
