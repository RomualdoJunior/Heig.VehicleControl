using Heig.VehicleControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heig.VehicleControl.Application.ViewModels
{
    public class ChecklistViewModel
    {
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }
        public Guid ChecklistTemplateId { get; set; }
        public List<AnswerViewModel> Answers { get; set; }
    }
}
