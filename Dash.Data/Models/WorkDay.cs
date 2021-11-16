using System;
using System.Collections.Generic;

namespace Dash.Data.Models
{
    public class WorkDay
    {
        public List<Shift> Shifts { get; set; }

        public DateTime Date { get; set; }

        public override string ToString()
        {
            return Date.ToShortDateString() + " Shifts: " + Shifts.Count.ToString();
        }
    }
}
