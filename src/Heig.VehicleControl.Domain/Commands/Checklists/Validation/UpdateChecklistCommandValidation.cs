using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heig.VehicleControl.Domain.Commands.Checklists.Validation
{
    public class UpdateChecklistCommandValidation : ChecklistValidation<UpdateChecklistCommand>
    {
        public UpdateChecklistCommandValidation()
        {
            ValidateChecklistTemplateId();
            ValidateVehicleId();
        }
    }
}
