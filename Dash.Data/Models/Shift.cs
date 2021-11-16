using System;

namespace Dash.Data.Models
{
    public class Shift
    {
        public int ActiveMinutes { get; set; }

        //StartTime and EndTime

        public int NumberEquipments { get; set; }

        public Shifts Type { get; set; }
    }
}
