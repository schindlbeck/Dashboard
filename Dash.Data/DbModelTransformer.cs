using Dash.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dash.Data
{
    internal static class DbModelTransformer
    {
        public static DbWorkDay Mapp(WorkDay day)
        {
            DbWorkDay workDay = new DbWorkDay();
            workDay.Date = day.Date;
            workDay.ProductionMinutes = day.Shifts.Sum(s => s.ActiveMinutes);
            workDay.DetailInfo = JsonSerializer.Serialize(day);

            return workDay;
        }

        public static WorkDay Mapp(DbWorkDay dbDay)
        {
            var workDay = JsonSerializer.Deserialize<WorkDay>(dbDay.DetailInfo);
            return workDay;
        }
    }
}
