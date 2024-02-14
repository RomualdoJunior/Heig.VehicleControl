using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heig.VehicleControl.Application.ViewModels
{
    public class AnswerViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string AdditionalObservation { get; set; }
        public bool Ok { get; set; }
    }
}
