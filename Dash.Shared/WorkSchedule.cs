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
            SetHolidays();
            SetUpRange(year, cwStart, cwEnd);
        }

        private void SetHolidays()
        {
            Holidays = (from a in DbContext.Holidays
                        orderby a.Date ascending
                        select a).ToList();
        }

        internal void SetUpRange(int year, int cwStart, int cwEnd)
        {
            if (cwStart > cwEnd)
            {
                WorkWeeks = AddWorkDays(cwStart, WeeksInYear(year), year);
                WorkWeeks = AddWorkDays(1, cwEnd, year + 1);
            }
            else
            {
                WorkWeeks = AddWorkDays(cwStart, cwEnd, year);
            }
        }

        private static int WeeksInYear(int year)
        {
            return ISOWeek.GetWeeksInYear(year);
        }

        internal List<WorkWeek> AddWorkDays(int cwStart, int cwEnd, int year)
        {
            DbContext.WorkDays.RemoveRange(DbContext.WorkDays);
            DbContext.SaveChanges();

            for (int i = cwStart; i <= cwEnd; i++)
            {
                WorkWeeks.Add(SetUpDefaultWeekSchedule(i, year));
            }

            return WorkWeeks;
        }

        public WorkWeek SetUpDefaultWeekSchedule(int calendarWeek, int year)
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

                if (!Holidays.Exists(h => h.Date == workDay.Date))
                {
                    workWeek.WorkDays.Add(workDay);
                    DbContext.WorkDays.Add(new DbWorkDay() { Date = workDay.Date, ProductionMinutes = workDay.Shifts.Sum(s => s.ActiveMinutes * s.NumberEquipments), WorkDay = workDay });
                    DbContext.SaveChanges();
                }
            }

            return workWeek;
        }

        public void AddSaturday(int calenderWeek)
        {
            if (WorkWeeks.Exists(w => w.CalendarWeek == calenderWeek))
            {
                var saturdayDate = WorkWeeks.First(w => w.CalendarWeek == calenderWeek).WorkDays[4].Date.AddDays(1);
                WorkDay saturday = new() { Date = saturdayDate, Shifts = new() };
                saturday.Shifts.Add(GetMorningShift());

                WorkWeeks.First(w => w.CalendarWeek == calenderWeek).WorkDays.Add(saturday);
            }
            else
            {
                //Reaction if calendarweek isn't in the workweeks
            }
        }

        public void DeleteWorkday(WorkDay day, WorkWeek week)
        {
            WorkWeeks.First(w => w.CalendarWeek == week.CalendarWeek).WorkDays.Remove(day);
        }

        public void AddShift(Shifts shift, WorkDay day, WorkWeek week)
        {
            WorkWeeks.First(w => w.CalendarWeek == week.CalendarWeek).WorkDays.First(w => w.Date == day.Date).Shifts.Add(GetShift(shift));
        }

        public void DeleteShift(Shifts shift, WorkDay day, WorkWeek week)
        {
            var deletedShift = WorkWeeks.First(w => w.CalendarWeek == week.CalendarWeek).WorkDays.First(w => w.Date == day.Date).Shifts.First(s => s.Type == shift);
            WorkWeeks.First(w => w.CalendarWeek == week.CalendarWeek).WorkDays.First(w => w.Date == day.Date).Shifts.Remove(deletedShift);
        }

        internal static Shift GetShift(Shifts shifts)
        {
            return shifts switch
            {
                Shifts.morning => GetMorningShift(),
                Shifts.evening => GetEveningShift(),
                Shifts.night => GetNightShift(),
                _ => null
            };
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

        //TODO : delete for productive use
        public void SetHolidays(List<DateTime> holidays)
        {
            foreach (DateTime holiday in holidays)
            {
                var week = ISOWeek.GetWeekOfYear(holiday);
                var obj = WorkWeeks.First(w => w.CalendarWeek == week).WorkDays.First(w => w.Date == holiday);
                WorkWeeks.First(w => w.CalendarWeek == week).WorkDays.Remove(obj);
            }
        }

        public void ChangeNumberEquipments(int value, Shifts shift, WorkWeek week, WorkDay day)
        {
            WorkWeeks.First(w => w.CalendarWeek == week.CalendarWeek).WorkDays.First(d => d.Date == day.Date).Shifts.First(s => s.Type == shift).NumberEquipments = value;
        }
    }
}
