using Dash.Shared;
using System;
using System.Collections.Generic;
using Xunit;

namespace DashSharedTest
{
    public class WorkScheduleTest
    {
        [Fact]
        public void FirstDayOfWeek_Test()
        {
            //Arrange

            //Act
            var date = WorkSchedule.FirstDateOfWeekISO8601(2021, 45);

            //Assert
            Assert.Equal(new DateTime(2021, 11, 08), date);
        }

        [Fact]
        public void SetUpDefaultWeekSchedule_Test()
        {
            //Arrange
            WorkSchedule workSchedule = new(new List<DateTime>(), new List<DateTime>(), DateTime.Now);

            //Act
            var result = workSchedule.SetUpDefaultWeekSchedule(45);

            //Assert
            Assert.Equal(5, result.Count);
            Assert.Equal(new DateTime(2021, 11, 08), result[0].Date);
            Assert.Equal(new DateTime(2021, 11, 09), result[1].Date);
            Assert.Equal(new DateTime(2021, 11, 10), result[2].Date);
            Assert.Equal(new DateTime(2021, 11, 11), result[3].Date);
            Assert.Equal(new DateTime(2021, 11, 12), result[4].Date);

        }
    }
}
