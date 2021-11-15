using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dash.Shared
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
