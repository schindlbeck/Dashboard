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
        //private readonly List<DateTime> _holidays;
        //private readonly List<DateTime> _saturdays;

        //private WorkDay CurrentDay = new();
        //private Calendar myCal;


        //public WorkSchedule(List<DateTime> holidays, List<DateTime> saturdays, DateTime start)
        //{
        //    _holidays = holidays;
        //    _saturdays = saturdays;
        //    CurrentDay.Date = start;
        //    myCal = CultureInfo.InvariantCulture.Calendar;
        //}

        public static List<WorkWeek> SetUpRange(int year, int cwStart, int cwEnd)
        {
            List<WorkWeek> WorkWeeks = new();

            var calendarWeeks = ManageCalendar.GetCalendarWeeksInYear(year);

            if (cwStart > cwEnd)
            {
                WorkWeeks = AddWorkDays(cwEnd, WorkWeeks, calendarWeeks, year);
                WorkWeeks = AddWorkDays(1, WorkWeeks, cwEnd, year+1);

                return WorkWeeks;
            }

            WorkWeeks = AddWorkDays(cwStart, WorkWeeks, cwEnd, year);
           
            return WorkWeeks;
        }

        private static List<WorkWeek> AddWorkDays(int start, List<WorkWeek> WorkWeeks, int end, int year)
        {
            for (int i = start; i <= end; i++)
            {
                WorkWeek workWeek = new();

                workWeek.CalendarWeek = i;
                workWeek.WorkDays = SetUpDefaultWeekSchedule(i, year);

                WorkWeeks.Add(workWeek);
            }

            return WorkWeeks;
        }

        public static List<WorkDay> SetUpDefaultWeekSchedule(int calendarWeek, int year)
        {
            List<WorkDay> workDays = new();

            for (int i = 0; i < 5; i++)
            {
                WorkDay workDay = new();
                workDay.Shifts = new();
                workDay.Shifts.Add(GetMorningShift());
                workDay.Shifts.Add(GetEveningShift());

                workDay.Date = ManageCalendar.FirstDateOfWeekISO8601(year, calendarWeek).AddDays(i);

                workDays.Add(workDay);
            }

            return workDays;
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


    }
}
