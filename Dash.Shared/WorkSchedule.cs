using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dash.Shared
{
    public class WorkSchedule
    {
        private readonly List<DateTime> _holidays;
        private readonly List<DateTime> _saturdays;

        private WorkDay CurrentDay = new();
        private Calendar myCal;


        public WorkSchedule(List<DateTime> holidays, List<DateTime> saturdays, DateTime start)
        {
            _holidays = holidays;
            _saturdays = saturdays;
            CurrentDay.Date = start;
            myCal = CultureInfo.InvariantCulture.Calendar;
        }

        public List<WorkDay> SetUpDefaultWeekSchedule(int calendarWeek)
        {
            List<WorkDay> workDays = new();
            

            for(int i = 0; i<5; i++)
            {
                WorkDay workDay = new();
                workDay.Shifts = new();
                workDay.Shifts.Add(GetMorningShift());
                workDay.Shifts.Add(GetEveningShift());

                workDay.Date = FirstDateOfWeekISO8601(GetYear(calendarWeek), calendarWeek).AddDays(i);

                workDays.Add(workDay);

            }

            return workDays;
        }

        private int GetYear(int cw)
        {
            var today = DateTime.Today;
            var week = myCal.GetWeekOfYear(today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
             if(week <= cw)
            {
                return today.Year;
            }
            return today.Year + 1;
        }

        private static Shift GetMorningShift()
        {
            Shift morningShift = new();
            morningShift.ActiveMinutes = 480;
            morningShift.NumberEquipments = 3;

            return morningShift;
        }

        private static Shift GetEveningShift()
        {
            Shift morningShift = new();
            morningShift.ActiveMinutes = 480;
            morningShift.NumberEquipments = 3;

            return morningShift;
        }

        public static DateTime FirstDateOfWeekISO8601(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            // Use first Thursday in January to get first week of the year as
            // it will never be in Week 52/53
            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            // As we're adding days to a date in Week 1,
            // we need to subtract 1 in order to get the right date for week #1
            if (firstWeek == 1)
            {
                weekNum -= 1;
            }

            // Using the first Thursday as starting week ensures that we are starting in the right year
            // then we add number of weeks multiplied with days
            var result = firstThursday.AddDays(weekNum * 7);

            // Subtract 3 days from Thursday to get Monday, which is the first weekday in ISO8601
            return result.AddDays(-3);
        }
    }
}
