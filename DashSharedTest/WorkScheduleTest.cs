using Dash.Shared;
using System;
using System.Collections.Generic;
using Xunit;

namespace DashSharedTest
{
    public class WorkScheduleTest
    {
        [Fact]
        public void SetUpDefaultWeekSchedule_CW452021_Test()
        {
            //Arrange

            //Act
            var result = WorkSchedule.SetUpDefaultWeekSchedule(45, 2021);

            //Assert
            Assert.Equal(5, result.Count);
            Assert.Equal(new DateTime(2021, 11, 08), result[0].Date);
            Assert.Equal(new DateTime(2021, 11, 09), result[1].Date);
            Assert.Equal(new DateTime(2021, 11, 10), result[2].Date);
            Assert.Equal(new DateTime(2021, 11, 11), result[3].Date);
            Assert.Equal(new DateTime(2021, 11, 12), result[4].Date);

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
    }
}
