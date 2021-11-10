using Dash.Shared;
using System;
using System.Collections.Generic;
using Xunit;

namespace DashSharedTest
{
    public class WorkScheduleTest
    {
        [Fact]
        public void SetUpDefaultWeekSchedule_CW1Year2020_Test()
        {
            //Arrange

            //Act
            var result = WorkSchedule.SetUpDefaultWeekSchedule(1, 2020);

            //Assert
            Assert.Equal(5, result.Count);
            Assert.Equal(new DateTime(2019, 12, 30), result[0].Date);
            Assert.Equal(new DateTime(2019, 12, 31), result[1].Date);
            Assert.Equal(new DateTime(2020, 01, 01), result[2].Date);
            Assert.Equal(new DateTime(2020, 01, 02), result[3].Date);
            Assert.Equal(new DateTime(2020, 01, 03), result[4].Date);
        }

        [Fact]
        public void SetupRange_Cw1To52_Test()
        {
            //Arrange

            //Act
            var result = WorkSchedule.SetUpRange(2021, 1, 52);

            //Assert
            Assert.Equal(52, result.Count);
            Assert.Equal(new DateTime(2021, 1, 4), result[0].WorkDays[0].Date);
            Assert.Equal(new DateTime(2021, 12, 31), result[51].WorkDays[4].Date);
        }

        [Fact]
        public void SetupRange_Cw50To05_YearChanged_Test()
        {
            //Arrange

            //Act
            var result = WorkSchedule.SetUpRange(2021, 50, 5);

            //Assert
            Assert.Equal(8, result.Count);
            Assert.Equal(new DateTime(2021, 12, 13), result[0].WorkDays[0].Date);
            Assert.Equal(new DateTime(2022, 02, 04), result[7].WorkDays[4].Date);
        }

        [Fact]
        public void AddWorkDays_CW1To5Year2020_Test()
        {
            //Arrange


            //Act
            var result = WorkSchedule.AddWorkDays(1, new List<WorkWeek>(), 5, 2020);

            //Assert
            Assert.Equal(5, result.Count);

            Assert.Equal(new DateTime(2019, 12, 30), result[0].WorkDays[0].Date);
            Assert.Equal(1, result[0].CalendarWeek);

            Assert.Equal(new DateTime(2020, 01, 22), result[3].WorkDays[2].Date);
            Assert.Equal(4, result[3].CalendarWeek);
        }
    }
}
