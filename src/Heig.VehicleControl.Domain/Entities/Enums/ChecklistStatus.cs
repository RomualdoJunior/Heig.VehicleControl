using System.ComponentModel;

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