using Dash.Data;
using Dash.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DashSharedTest
{
    public class WeekContainerTestFixture : IDisposable
    {
        public WeekContainerTestFixture()
        {

        }

        public void Dispose()
        {
            
        }

       public static DbWorkWeek GetDbWorkWeek()
        {
            return new DbWorkWeek() { CalendarWeek = 48, ProductionMinutes = 14440, Year = 2021};
        }

    }
}
