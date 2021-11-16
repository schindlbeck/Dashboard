using Dash.Data;
using Dash.Data.Models;
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
        public List<Holiday> Holidays { get; set; }

        public DashDbContext DbContext { get; set; }


        public WorkSchedule(int year, int cwStart, int cwEnd, DashDbContext dbContext)
        {
            DbContext = dbContext;
            WorkWeeks = new();
            if (cwEnd == 53) cwEnd = WeeksInYear(year);
            SetUpRange(year, cwStart, cwEnd);
            SetHolidays();
            RemoveHolidays();
        }

        private void SetHolidays()
        {
            Holidays = (from a in DbContext.Holidays
                        orderby a.Date ascending
                        select a).ToList();
        }

        private void RemoveHolidays()
        {
            foreach (var holiday in Holidays)
            {
                var day = WorkWeeks.Where(w => w.CalendarWeek == ISOWeek.GetWeekOfYear(holiday.Date)).FirstOrDefault().WorkDays.Where(d => d.Date == holiday.Date).FirstOrDefault();
                if (day != null)
                {
                    WorkWeeks.Where(w => w.CalendarWeek == ISOWeek.GetWeekOfYear(holiday.Date)).FirstOrDefault().WorkDays.Remove(day);
                }
            }
        }

        internal void SetUpRange(int year, int cwStart, int cwEnd)
        {
            if (cwStart > cwEnd)
            {
                WorkWeeks = AddWorkDays(cwStart, WorkWeeks, WeeksInYear(year), year);
                WorkWeeks = AddWorkDays(1, WorkWeeks, cwEnd, year + 1);
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
            if (WorkWeeks.Exists(w => w.CalendarWeek == calenderWeek))
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

        public void DeleteWorkday(WorkDay day, WorkWeek week)
        {
            WorkWeeks.Where(w => w.CalendarWeek == week.CalendarWeek).First().WorkDays.Remove(day);
        }

        public void AddShift(Shifts shift, WorkDay day, WorkWeek week)
        {
            WorkWeeks.Where(w => w.CalendarWeek == week.CalendarWeek).First().WorkDays.Where(w => w.Date == day.Date).First().Shifts.Add(GetShift(shift));
        }

        public void DeleteShift(Shifts shift, WorkDay day, WorkWeek week)
        {
            var dShift = WorkWeeks.Where(w => w.CalendarWeek == week.CalendarWeek).First().WorkDays.Where(w => w.Date == day.Date).First().Shifts.Where(s => s.Type == shift).First();
            WorkWeeks.Where(w => w.CalendarWeek == week.CalendarWeek).First().WorkDays.Where(w => w.Date == day.Date).First().Shifts.Remove(dShift);
        }

        private static Shift GetShift(Shifts shifts)
        {
            return shifts switch
            {
                Shifts.morning => GetMorningShift(),
                Shifts.evening => GetEveningShift(),
                Shifts.night => GetNightShift(),
                _ => null
            };
        }

        //TODO : delete for productive use
        public void SetHolidays(List<DateTime> holidays)
        {
            foreach (DateTime holiday in holidays)
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
            morningShift.Type = Shifts.morning;

            return morningShift;
        }

        private static Shift GetEveningShift()
        {
            Shift eveningShift = new();
            eveningShift.ActiveMinutes = 480;
            eveningShift.NumberEquipments = 3;
            eveningShift.Type = Shifts.evening;

            return eveningShift;
        }

        private static Shift GetNightShift()
        {
            Shift nightSchift = new();
            nightSchift.ActiveMinutes = 480;
            nightSchift.NumberEquipments = 3;
            nightSchift.Type = Shifts.night;

            return nightSchift;
        }

        public void ChangeNumberShifts(int value, Shifts shift, WorkWeek week, WorkDay day)
        {
            WorkWeeks.Where(w => w.CalendarWeek == week.CalendarWeek).First().WorkDays.Where(d => d.Date == day.Date).First().Shifts.Where(s => s.Type == shift).First().NumberEquipments = value;
        }
    }
}
