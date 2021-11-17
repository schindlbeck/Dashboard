using System.Collections.Generic;

namespace Dash.Data.Models
{
    public class WorkWeek
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int CalendarWeek { get; set; }
        public List<WorkDay> WorkDays { get; set; }

        public override string ToString()
        {
            return "CW: " + CalendarWeek.ToString() + " Days: " + WorkDays.Count.ToString();
        }
    }
}
