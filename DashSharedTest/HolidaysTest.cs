using Dash.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace DashSharedTest
{
    public class HolidaysTest
    {
        [Theory]
        [ClassData(typeof(GetEasterSundayTestData))]
        public void GetEasterSunday_Theory(int year, DateTime dateOstersonntag)
        {
            //Arrange
            Holidays holidays2021 = new(year);

            //Act
            var result = holidays2021.GetEasterSundayDate();

            //Assert
            Assert.Equal(dateOstersonntag, result);

        }

        [Theory]
        [ClassData(typeof(SetHolidayListTestData))]
        public void SetHolidayList_Theory(int year, DateTime dateKarfreitag, DateTime dateFronleichnam)
        {
            //Act
            Holidays holidays = new(year);

            //Assert
            Assert.Equal(14, holidays.HolidayList.Count);

            Assert.Equal(dateKarfreitag, holidays.HolidayList[2].Date);
            Assert.Equal("Karfreitag", holidays.HolidayList[2].Name);

            Assert.Equal(dateFronleichnam, holidays.HolidayList[8].Date);
            Assert.Equal("Fronleichnam", holidays.HolidayList[8].Name);

        }

        [Theory]
        [ClassData(typeof(SelectedMonthsTestData))]
        public void SelectedMonths_Theory(int year, int count, DateTime firstDate, DateTime seventhDate)
        {
            //Arrange
            Holidays holidays = new(year);

            //Act
            holidays.SelectedMonths(6, 12);

            //Assert
            Assert.Equal(count, holidays.HolidayList.Count);
            Assert.Equal(firstDate, holidays.HolidayList[0].Date);
            Assert.Equal(seventhDate, holidays.HolidayList[4].Date);
        }
    }

    public class SelectedMonthsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2022, 7, new DateTime(2022, 06, 06), new DateTime(2022, 11, 01) };
            yield return new object[] { 2023, 6, new DateTime(2023, 06, 08), new DateTime(2023, 12, 25) };
            yield return new object[] { 2024, 5, new DateTime(2024, 08, 15), new DateTime(2024, 12, 26) };
            yield return new object[] { 2025, 7, new DateTime(2025, 06, 09), new DateTime(2025, 11, 01) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class GetEasterSundayTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2022, new DateTime(2022, 4, 17) };
            yield return new object[] { 2023, new DateTime(2023, 4, 9) };
            yield return new object[] { 2024, new DateTime(2024, 3, 31) };
            yield return new object[] { 2025, new DateTime(2025, 4, 20) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class SetHolidayListTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2022, new DateTime(2022, 4, 15), new DateTime(2022, 6, 16) };
            yield return new object[] { 2023, new DateTime(2023, 4, 7), new DateTime(2023, 6, 8) };
            yield return new object[] { 2024, new DateTime(2024, 3, 29), new DateTime(2024, 5, 30) };
            yield return new object[] { 2025, new DateTime(2025, 4, 18), new DateTime(2025, 6, 19) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
