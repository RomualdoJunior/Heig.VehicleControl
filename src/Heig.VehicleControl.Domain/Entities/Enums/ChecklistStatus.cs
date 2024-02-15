using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heig.VehicleControl.Domain.Entities.Enums
{
    public enum ChecklistStatus
    {
        [Description("Created")]
        Created = 1,
        [Description("Started")]
        Started = 2,
        [Description("Closed")]
        Closed = 3
    }
}
