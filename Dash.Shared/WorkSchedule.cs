using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dash.Shared
{
    class WorkSchedule
    {
        private readonly List<DateTime> _holidays;
        private readonly List<DateTime> _saturdays;

        private WorkDay CurrentDay;
        private Calendar myCal;


        public WorkSchedule(List<DateTime> holidays, List<DateTime> saturdays, DateTime startSimulation)
        {
            _holidays = holidays;
            _saturdays = saturdays;
            CurrentDay.Date = startSimulation;
            myCal = CultureInfo.InvariantCulture.Calendar;
        }

        public void SetUpDefaultSchedule()
        {
            
        }
    }
}
