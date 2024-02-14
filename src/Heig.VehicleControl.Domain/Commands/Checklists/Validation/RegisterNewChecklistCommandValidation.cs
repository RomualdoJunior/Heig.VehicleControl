using Heig.VehicleControl.Domain.Commands.ChecklistTemplates.Validation;
using Heig.VehicleControl.Domain.Commands.ChecklistTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heig.VehicleControl.Domain.Commands.Checklists.Validation
{

    public class RegisterNewChecklistCommandValidation : ChecklistValidation<RegisterNewChecklistCommand>
    {
        public RegisterNewChecklistCommandValidation()
        {
            ValidateChecklistTemplateId();
            ValidateVehicleId();
        }
    }

}
