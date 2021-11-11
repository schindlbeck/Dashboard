using Dash.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace DashSharedTest
{
    public class ManageCalendarTest
    {
        [Theory]
        [ClassData(typeof(FirstDayOfWeekTestData))]
        public void FirstDayOfWeek_Theory(int year, int cw, DateTime expected)
        {
            //Arrange

            //Act
            var date1 = ManageCalendar.FirstDateOfWeekISO8601(year, cw);

            //Assert
            Assert.Equal(expected, date1);
        }
    }

    public class FirstDayOfWeekTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2022, 52, new DateTime(2022, 12, 26)};
            yield return new object[] { 2023, 01, new DateTime(2023, 01, 02) };
            yield return new object[] { 2025, 01, new DateTime(2024, 12, 30) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
