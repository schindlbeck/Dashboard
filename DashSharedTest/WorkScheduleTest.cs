using Dash.Data;
using Dash.Data.Models;
using Dash.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DashSharedTest
{
    public class WorkScheduleTest
    {
        [Fact]
        public void SetUpDefaultWeekSchedule_CW1Year2020_Test()
        {
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<DashDbContext>();
            optionsBuilder.UseInMemoryDatabase("DashTest1");
            var dbContext = new DashDbContext(optionsBuilder.Options);

            WorkSchedule workSchedule = new(2020, 1, 52, dbContext);

            //Act
            var result = workSchedule.SetUpDefaultWeekSchedule(1, 2020);

            //Assert
            Assert.Equal(5, result.WorkDays.Count);
            Assert.Equal(new DateTime(2019, 12, 30), result.WorkDays[0].Date);
            Assert.Equal(new DateTime(2019, 12, 31), result.WorkDays[1].Date);
            Assert.Equal(new DateTime(2020, 01, 01), result.WorkDays[2].Date);
            Assert.Equal(new DateTime(2020, 01, 02), result.WorkDays[3].Date);
            Assert.Equal(new DateTime(2020, 01, 03), result.WorkDays[4].Date);
        }

        [Fact]
        public void AddSaturday_SaturdayInCW25_SaturdayAdded_Test()
        {
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<DashDbContext>();
            optionsBuilder.UseInMemoryDatabase("DashTest2");
            var dbContext = new DashDbContext(optionsBuilder.Options);

            WorkSchedule workSchedule = new(2021, 1, 52, dbContext);

            //Act
            workSchedule.AddSaturday(25);

            //Assert
            Assert.Equal(6, workSchedule.WorkWeeks[24].WorkDays.Count);
            Assert.Equal(new DateTime(2021, 06, 26), workSchedule.WorkWeeks[24].WorkDays[5].Date);
        }

        [Fact]
        public void SetHolidays_TwoHolidays_DatesRemoved_Test()
        {
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<DashDbContext>();
            optionsBuilder.UseInMemoryDatabase("DashTest3");
            var dbContext = new DashDbContext(optionsBuilder.Options);

            WorkSchedule workSchedule = new(2021, 1, 10, dbContext);
            List<DateTime> holidays = new();
            holidays.Add(new DateTime(2021, 01, 06));
            holidays.Add(new DateTime(2021, 02, 16));

            //Act
            workSchedule.SetHolidays(holidays);

            //Assert
            Assert.Equal(4, workSchedule.WorkWeeks[0].WorkDays.Count);
            Assert.Equal(4, workSchedule.WorkWeeks[6].WorkDays.Count);

            Assert.Equal(new DateTime(2021, 01, 07), workSchedule.WorkWeeks[0].WorkDays[2].Date);
            Assert.Equal(new DateTime(2021, 02, 17), workSchedule.WorkWeeks[6].WorkDays[1].Date);
        }

        [Fact]
        public void AddWorkDays_CW1To5Year2020_Test()
        {
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<DashDbContext>();
            optionsBuilder.UseInMemoryDatabase("DashTest4");
            var dbContext = new DashDbContext(optionsBuilder.Options);

            WorkSchedule workSchedule = new(2020, 1, 10, dbContext);
            workSchedule.WorkWeeks.Clear();

            //Act
            var result = workSchedule.AddWorkDays(1, 5, 2020);

            //Assert
            Assert.Equal(5, result.Count);

            Assert.Equal(new DateTime(2019, 12, 30), result[0].WorkDays[0].Date);
            Assert.Equal(1, result[0].CalendarWeek);

            Assert.Equal(new DateTime(2020, 01, 22), result[3].WorkDays[2].Date);
            Assert.Equal(4, result[3].CalendarWeek);
        }

        [Fact]
        public void DeleteWorkday_Test()
        {
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<DashDbContext>();
            optionsBuilder.UseInMemoryDatabase("DashTest5");
            var dbContext = new DashDbContext(optionsBuilder.Options);

            WorkSchedule workSchedule = new(2021, 1, 52, dbContext);
            var day = workSchedule.WorkWeeks.First(w => w.CalendarWeek == 46).WorkDays.First(d => d.Date == new DateTime(2021, 11, 18));

            //Act
            workSchedule.DeleteWorkday(day, new WorkWeek() { CalendarWeek = 46});

            //Assert
            Assert.Equal(4 , workSchedule.WorkWeeks.First(w => w.CalendarWeek == 46).WorkDays.Count);
        }

        [Theory]
        [InlineData(Shifts.morning, 480, 3)]
        [InlineData(Shifts.evening, 480, 3)]
        [InlineData(Shifts.night, 480, 3)]
        public void GetShift_Theory(Shifts shift, int activeMinutes, int numberEquipments)
        {
            //Act
            var result = WorkSchedule.GetShift(shift);

            //Assert
            Assert.Equal(shift, result.Type);
            Assert.Equal(activeMinutes, result.ActiveMinutes);
            Assert.Equal(numberEquipments, result.NumberEquipments);
        }

        [Fact]
        public void GetShift_null_Test()
        {
            //Act
            var result = WorkSchedule.GetShift((Shifts)Int32.MaxValue);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void DeleteShift_Test()
        {
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<DashDbContext>();
            optionsBuilder.UseInMemoryDatabase("DashTest6");
            var dbContext = new DashDbContext(optionsBuilder.Options);

            WorkSchedule workSchedule = new(2021, 1, 52, dbContext);
            var day = workSchedule.WorkWeeks.Where(w => w.CalendarWeek == 46).First().WorkDays.Where(d => d.Date == new DateTime(2021, 11, 18)).First();

            //Act
            workSchedule.DeleteShift(Shifts.morning, day, new WorkWeek() { CalendarWeek = 46 });

            //Assert
            Assert.Single(workSchedule.WorkWeeks.Where(w => w.CalendarWeek == 46).First().WorkDays.Where(d => d.Date == new DateTime(2021, 11, 18)).First().Shifts);
            Assert.Equal(Shifts.evening, workSchedule.WorkWeeks.First(w => w.CalendarWeek == 46).WorkDays.First(d => d.Date == day.Date).Shifts[0].Type);
        }

        [Fact]
        public void ChangeNumberEquipments_Test()
        {
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<DashDbContext>();
            optionsBuilder.UseInMemoryDatabase("DashTest7");
            var dbContext = new DashDbContext(optionsBuilder.Options);

            WorkSchedule workSchedule = new(2021, 1, 52, dbContext);
            var day = workSchedule.WorkWeeks.Where(w => w.CalendarWeek == 46).First().WorkDays.Where(d => d.Date == new DateTime(2021, 11, 18)).First();

            //Act
            workSchedule.ChangeNumberEquipments(4, Shifts.morning, new WorkWeek() { CalendarWeek = 46 }, day);

            //Assert
            Assert.Equal(4, workSchedule.WorkWeeks.First(w => w.CalendarWeek == 46).WorkDays.First(d => d.Date == day.Date).Shifts.First(s => s.Type == Shifts.morning).NumberEquipments);

        }

        [Theory]
        [ClassData(typeof(WorkScheduleTestData))]
        public void SetupRange_Theory(int year, int startCw, int endCw, int weeks, DateTime firstWorkday, DateTime lastWorkday)
        {
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<DashDbContext>();
            optionsBuilder.UseInMemoryDatabase("DashTest8");
            var dbContext = new DashDbContext(optionsBuilder.Options);

            //Act
            WorkSchedule workSchedule = new(year, startCw, endCw, dbContext);

            //Assert
            Assert.Equal(weeks, workSchedule.WorkWeeks.Count);
            Assert.Equal(firstWorkday, workSchedule.WorkWeeks[0].WorkDays[0].Date);
            Assert.Equal(lastWorkday, workSchedule.WorkWeeks[weeks - 1].WorkDays[4].Date);
        }
    }

    public class WorkScheduleTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2020, 1, 53, 53, new DateTime(2019, 12, 30), new DateTime(2021, 01, 01) };
            yield return new object[] { 2021, 1, 52, 52, new DateTime(2021, 1, 4), new DateTime(2021, 12, 31) };
            yield return new object[] { 2022, 1, 52, 52, new DateTime(2022, 1, 3), new DateTime(2022, 12, 30) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
