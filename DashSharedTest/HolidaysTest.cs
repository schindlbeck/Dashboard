using Dash.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DashSharedTest
{
    public class HolidaysTest
    {
        [Fact]
        public void GetEasterSundayDate_2022_Get17April_Test()
        {
            //Arrange
            Holidays holidays2021 = new(2022);
            //Act
            var result = holidays2021.GetEasterSundayDate();

            //Assert
            Assert.Equal(new DateTime(2022, 4, 17), result);
        }

        [Fact]
        public void GetEasterSundayDate_2023_Get9April_Test()
        {
            //Arrange
            Holidays holidays2021 = new(2023);
            //Act
            var result = holidays2021.GetEasterSundayDate();

            //Assert
            Assert.Equal(new DateTime(2023, 4, 9), result);
        }

        [Fact]
        public void GetEasterSundayDate_2024_Get17April_Test()
        {
            //Arrange
            Holidays holidays2021 = new(2024);
            //Act
            var result = holidays2021.GetEasterSundayDate();

            //Assert
            Assert.Equal(new DateTime(2024, 3, 31), result);
        }

        [Fact]
        public void SetHolidayList_2022_Test()
        {
            //Arrange

            //Act
            Holidays holidays = new(2022);

            //Assert
            Assert.Equal(14, holidays.HolidayList.Count);

            Assert.Equal(new DateTime(2022, 04, 15), holidays.HolidayList[2].Date);
            Assert.Equal("Karfreitag", holidays.HolidayList[2].Name);

            Assert.Equal(new DateTime(2022, 06, 16), holidays.HolidayList[8].Date);
            Assert.Equal("Fronleichnam", holidays.HolidayList[8].Name);

        }

        [Fact]
        public void SetHolidayList_2024_Test()
        {
            //Arrange

            //Act
            Holidays holidays = new(2024);

            //Assert
            Assert.Equal(14, holidays.HolidayList.Count);

            Assert.Equal(new DateTime(2024, 03, 29), holidays.HolidayList[2].Date);
            Assert.Equal("Karfreitag", holidays.HolidayList[2].Name);

            Assert.Equal(new DateTime(2024, 05, 30), holidays.HolidayList[8].Date);
            Assert.Equal("Fronleichnam", holidays.HolidayList[8].Name);

        }


        [Fact]
        public void SetHolidayList_2025_Test()
        {
            //Arrange

            //Act
            Holidays holidays = new(2025);

            //Assert
            Assert.Equal(14, holidays.HolidayList.Count);

            Assert.Equal(new DateTime(2025, 04, 18), holidays.HolidayList[2].Date);
            Assert.Equal("Karfreitag", holidays.HolidayList[2].Name);

            Assert.Equal(new DateTime(2025, 06, 19), holidays.HolidayList[8].Date);
            Assert.Equal("Fronleichnam", holidays.HolidayList[8].Name);

        }


    }
}
