using Heig.VehicleControl.Domain.Commands.QuestionTemplates.Validation;
using Heig.VehicleControl.Domain.Commands.QuestionTemplates;
using Heig.VehicleControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heig.VehicleControl.Domain.Commands.ChecklistTemplates.Validation;

namespace Heig.VehicleControl.Domain.Commands.ChecklistTemplates
{
    public class RegisterNewChecklistTemplateCommand : ChecklistTemplateCommand
    {
        public RegisterNewChecklistTemplateCommand(string title, List<QuestionTemplate> questions)
        {
            Title = title;
            Questions = questions;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewChecklistTemplateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

       
    }
}
