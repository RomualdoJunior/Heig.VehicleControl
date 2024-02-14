using Heig.VehicleControl.Domain.Common;
using Heig.VehicleControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heig.VehicleControl.Domain.Commands.Checklists
{
    public abstract class ChecklistCommand : Command
    {
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }
        public Guid ChecklistTemplateId { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
