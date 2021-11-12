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
        public List<WorkWeek> WorkWeeks { get; set; }


        public WorkSchedule(int year, int cwStart, int cwEnd)
        {
            WorkWeeks = new();
            if (cwEnd == 53) cwEnd = WeeksInYear(year);
            SetUpRange(year, cwStart, cwEnd);
        }

        internal void SetUpRange(int year, int cwStart, int cwEnd)
        {
            if (cwStart > cwEnd)
            {
                WorkWeeks = AddWorkDays(cwStart, WorkWeeks, WeeksInYear(year), year);
                WorkWeeks = AddWorkDays(1, WorkWeeks, cwEnd, year+1);
            }
            else
            {
                WorkWeeks = AddWorkDays(cwStart, WorkWeeks, cwEnd, year);
            }
        }
        
        private static int WeeksInYear(int year)
        {
            return ISOWeek.GetWeeksInYear(year);
        }

        internal static List<WorkWeek> AddWorkDays(int start, List<WorkWeek> WorkWeeks, int end, int year)
        {
            for (int i = start; i <= end; i++)
            {
                WorkWeeks.Add(SetUpDefaultWeekSchedule(i, year));
            }

            return WorkWeeks;
        }

        public static WorkWeek SetUpDefaultWeekSchedule(int calendarWeek, int year)
        {
            WorkWeek workWeek = new();
            workWeek.WorkDays = new();
            workWeek.CalendarWeek = calendarWeek;

            for (int i = 0; i < 5; i++)
            {
                WorkDay workDay = new();
                workDay.Shifts = new();
                workDay.Shifts.Add(GetMorningShift());
                workDay.Shifts.Add(GetEveningShift());

                workDay.Date = ManageCalendar.FirstDateOfWeekISO8601(year, calendarWeek).AddDays(i);

                workWeek.WorkDays.Add(workDay);
            }

            return workWeek;
        }

        public void AddSaturday(int calenderWeek)
        {
            if(WorkWeeks.Exists(w => w.CalendarWeek == calenderWeek))
            {
                var saturdayDate = WorkWeeks.Where(w => w.CalendarWeek == calenderWeek).First().WorkDays[4].Date.AddDays(1);
                WorkDay saturday = new() { Date = saturdayDate, Shifts = new() };
                saturday.Shifts.Add(GetMorningShift());

                WorkWeeks.Where(w => w.CalendarWeek == calenderWeek).First().WorkDays.Add(saturday);
            }
            else
            {
                //Reaction if calendarweek isn't in the workweeks
            }

        }

        public void SetHolidays(List<DateTime> holidays)
        {
            foreach(DateTime holiday in holidays)
            {
                var week = ISOWeek.GetWeekOfYear(holiday);
                var obj = WorkWeeks.Where(w => w.CalendarWeek == week).First().WorkDays.Where(w => w.Date == holiday).First();
                WorkWeeks.Where(w => w.CalendarWeek == week).First().WorkDays.Remove(obj);
            }
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
