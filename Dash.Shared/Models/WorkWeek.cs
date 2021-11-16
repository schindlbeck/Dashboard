using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dash.Shared
{
    public class WorkWeek
    {
        public int CalendarWeek { get; set; }
        public List<WorkDay> WorkDays { get; set; }

        public override string ToString()
        {
            return "CW: " + CalendarWeek.ToString() + " Days: " + WorkDays.Count.ToString();
        }
    }
}
