using Dash.Shared;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace DashSharedTest
{
    public class ManageCalendarTest
    {
        [Fact]
        public void FirstDayOfWeek_Test()
        {
            //Arrange

            //Act
            var date1 = ManageCalendar.FirstDateOfWeekISO8601(2021, 45);
            var date2 = ManageCalendar.FirstDateOfWeekISO8601(2022, 52);
            var date3 = ManageCalendar.FirstDateOfWeekISO8601(2023, 01);

            //Assert
            Assert.Equal(new DateTime(2021, 11, 08), date1);
            Assert.Equal(new DateTime(2022, 12, 26), date2);
            Assert.Equal(new DateTime(2023, 01, 02), date3);

        }

        [Theory]
        [InlineData(2021)]
        [InlineData(2022)]
        [InlineData(2023)]
        [InlineData(2024)]
        [InlineData(2025)]
        public void GetCalendarWeeksInYear_Get52Weeks_Test(int year)
        {
            //Act
            var result = ManageCalendar.GetCalendarWeeksInYear(year);

            //Assert
            Assert.Equal(52, result);
        }

        [Theory]
        [InlineData(2020)]
        [InlineData(2026)]
        public void GetCalendarWeeksInYear_Get53Weeks_Test(int year)
        {
            //Act
            var result = ManageCalendar.GetCalendarWeeksInYear(year);

            //Assert
            Assert.Equal(53, result);
        }


        //[Fact]
        //public void GetYear_CW23_GetNextYear_Test()
        //{
        //    //Arrange

        //    //Act
        //    var year = ManageCalendar.GetYear(23);

        //    //Assert
        //    Assert.Equal(2022, year);
        //}

        //[Fact]
        //public void GetYear_CurrentCalendarWeek_GetThisYear_Test()
        //{
        //    //Arrange
        //    Calendar myCal = CultureInfo.InvariantCulture.Calendar;

        //    var calendarWeek = myCal.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

        //    //Act
        //    var year = ManageCalendar.GetYear(calendarWeek);

        //    //Assert
        //    Assert.Equal(DateTime.Now.Year, year);
        //}

        //[Fact]
        //public void GetYear_CalendarWeekNotPassedThisYear_GetThisYear_Test()
        //{
        //    //Arrange
        //    Calendar myCal = CultureInfo.InvariantCulture.Calendar;

        //    var calendarWeek = myCal.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

        //    //Act
        //    var year = ManageCalendar.GetYear(calendarWeek + 1);

        //    //Assert
        //    Assert.Equal(DateTime.Now.Year, year);
        //}
    }
}
