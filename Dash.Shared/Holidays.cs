using Dash.Data.Models;
using Dash.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dash.Shared
{
    public class Holidays
    {
        private readonly int year;
        public List<Holiday> HolidayList { get; set; }
        public DashDbContext DbContext { get; set; }

        public Holidays(int year)
        {
            this.year = year;
            HolidayList = new();
            SetHolidayList();
        }

        public Holidays(int year, int monthStart, int monthEnd, DashDbContext dbContext)
        {
            DbContext = dbContext;
            this.year = year;
            HolidayList = new();
            SetHolidayList();
            SelectedMonths(monthStart, monthEnd);

            WriteInDatabase();
        }

        private void WriteInDatabase()
        {
            DbContext.Holidays.RemoveRange(DbContext.Holidays);
            DbContext.SaveChanges();

            DbContext.Holidays.AddRange(HolidayList);
        }

        internal void SelectedMonths(int monthStart, int monthEnd)
        {
            List<Holiday> newHolidayList = new();

            for (int i = monthStart; i <= monthEnd; i++)
            {
                newHolidayList.AddRange(HolidayList.Where(h => h.Date.Month == i).ToList());
            }

            HolidayList = newHolidayList;
        }

        private void SetHolidayList()
        {
            var easterSunday = GetEasterSundayDate();

            HolidayList.Add(new Holiday() { Date = new DateTime(year, 1, 1), Name = "Neujahr" });
            HolidayList.Add(new Holiday() { Date = new DateTime(year, 1, 6), Name = "Heilig Drei Könige" });
            HolidayList.Add(new Holiday() { Date = easterSunday.AddDays(-2), Name = "Karfreitag" });
            HolidayList.Add(new Holiday() { Date = easterSunday, Name = "Ostersonntag" });
            HolidayList.Add(new Holiday() { Date = easterSunday.AddDays(1), Name = "Ostermontag" });
            HolidayList.Add(new Holiday() { Date = new DateTime(year, 5, 1), Name = "Tag der Arbeit" });
            HolidayList.Add(new Holiday() { Date = easterSunday.AddDays(39), Name = "christi Himmelfahrt" });
            HolidayList.Add(new Holiday() { Date = easterSunday.AddDays(50), Name = "Pfingstmontag" });
            HolidayList.Add(new Holiday() { Date = easterSunday.AddDays(60), Name = "Fronleichnam" });
            HolidayList.Add(new Holiday() { Date = new DateTime(year, 8, 15), Name = "Mariä Himmelfahrt " });
            HolidayList.Add(new Holiday() { Date = new DateTime(year, 10, 3), Name = "Tag der deutschen Einheit" });
            HolidayList.Add(new Holiday() { Date = new DateTime(year, 11, 01), Name = "Allerheiligen" });
            HolidayList.Add(new Holiday() { Date = new DateTime(year, 12, 25), Name = "1. Weihnachsfeiertag" });
            HolidayList.Add(new Holiday() { Date = new DateTime(year, 12, 26), Name = "2. Weihnachsfeiertag" });
        }


        internal DateTime GetEasterSundayDate()
        {
            // https://de.wikipedia.org/wiki/Spencers_Osterformel
            var a = year % 19;                              // Mondparameter
            var b = year / 100;                             // Säkularzahl
            var c = year % 100;
            var d = b / 4;
            var e = b % 4;
            var f = (b + 8) / 25;
            var g = (b - f + 1) / 3;
            var h = (19 * a + b - d - g + 15) % 30;
            var i = c / 4;
            var k = c % 4;
            var l = (32 + 2 * e + 2 * i - h - k) % 7;
            var m = (a + 11 * h + 22 * l) / 451;
            var n = (h + l - 7 * m + 114) / 31;
            var p = (h + l - 7 * m + 114) % 31;

            return new DateTime(year, n, p + 1);
        }
    }

}
