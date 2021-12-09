using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dash.Data.Models
{
    public class PriorityWeek
    {
        public int Id { get; set; }
        public int CalendarWeek { get; set; }
        public int Year { get; set; }
        public int ProductionMinutes { get; set; }
        public List<Order> Orders { get; set; } = new();

    }
}
