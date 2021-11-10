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

        public static List<WorkWeek> SetUpRange(int cwStart, int cwEnd)
        {
            List<WorkWeek> WorkWeeks = new();

            var year = ManageCalendar.GetYear(cwStart);
            var calendarWeeks = ManageCalendar.GetCalendarWeeksInYear(year);

            //TODO : eliminate duplicated code, test function
            if (cwStart > cwEnd)
            {
                for (int i = cwEnd; i <= calendarWeeks; i++)
                {
                    WorkWeek workWeek = new();

                    workWeek.CalendarWeek = i;
                    workWeek.WorkDays = SetUpDefaultWeekSchedule(i);

                    WorkWeeks.Add(workWeek);
                }

                for (int i = 1; i <= cwStart; i++)
                {
                    WorkWeek workWeek = new();

                    workWeek.CalendarWeek = i;
                    workWeek.WorkDays = SetUpDefaultWeekSchedule(i);

                    WorkWeeks.Add(workWeek);
                }

                return WorkWeeks;
            }

            for (int i = cwStart; i <= cwEnd && i <= calendarWeeks; i++)
            {
                WorkWeek workWeek = new();

                workWeek.CalendarWeek = i;
                workWeek.WorkDays = SetUpDefaultWeekSchedule(i);

                WorkWeeks.Add(workWeek);
            }

            return WorkWeeks;
        }

        //private static int[] CheckCalendarWeeks(int cwStart, int cwEnd)
        //{
        //    if(cwStart> cw )
        //    {
        //        return new int[] { cwStart, cwEnd };
        //    }


        //}

        public static List<WorkDay> SetUpDefaultWeekSchedule(int calendarWeek)
        {
            List<WorkDay> workDays = new();

            for (int i = 0; i < 5; i++)
            {
                WorkDay workDay = new();
                workDay.Shifts = new();
                workDay.Shifts.Add(GetMorningShift());
                workDay.Shifts.Add(GetEveningShift());

                workDay.Date = ManageCalendar.FirstDateOfWeekISO8601(ManageCalendar.GetYear(calendarWeek), calendarWeek).AddDays(i);

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
