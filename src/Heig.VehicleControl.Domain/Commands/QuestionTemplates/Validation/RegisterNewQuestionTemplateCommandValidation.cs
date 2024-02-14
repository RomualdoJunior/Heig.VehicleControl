using Heig.VehicleControl.Domain.Commands.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heig.VehicleControl.Domain.Commands.QuestionTemplates;

namespace Heig.VehicleControl.Domain.Commands.QuestionTemplates.Validation
{
    public class RegisterNewQuestionTemplateCommandValidation : QuestionTemplateValidation<RegisterNewQuestionTemplateCommand>
    {
        public RegisterNewQuestionTemplateCommandValidation()
        {
            ValidateTitle();
        }
    }
}
