using Dash.Data;
using Dash.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DashSharedTest
{
    public class OrderSchedulerTest
    {
        [Fact]
        public void AddOrder_Test()
        {
            //Arrange

            var optionsBuilder = new DbContextOptionsBuilder<PriorityDbContext>();
            optionsBuilder.UseInMemoryDatabase("Test1");
            var dbContext = new PriorityDbContext(optionsBuilder.Options);

            OrderScheduler scheduler = new(dbContext);
            PrioListElement element = new() { CWPlanned = 48, DeliveryDate = new DateTime(2021, 12, 2), OrderNr = "A001", Project = "P1" };
            OrderContainer container = new(element);

            //Act
            scheduler.AddOrder(container);

            //Assert
            Assert.Equal(scheduler.Orders.First(), container);
        }

        [Fact]
        public void AddLastChangedItem_Test()
        {

        }
    }
}
