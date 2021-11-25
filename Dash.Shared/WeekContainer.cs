using Dash.Data.Models;
using Dash.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dash.Shared
{
    public class WeekContainer
    {
        public DbWorkWeek Week { get; set; }
        public List<PrioListElement> Orders { get; set; }

        public WeekContainer(DbWorkWeek week)
        {
            Week = week;
            Orders = new();
        }
    }
}
