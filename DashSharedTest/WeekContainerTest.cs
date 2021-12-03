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
    public class WeekContainerTest : IClassFixture<WeekContainerTestFixture>, IClassFixture<ManageOrdersTestFixture>
    {
        public WeekContainerTest(WeekContainerTestFixture weekContainerFixture, ManageOrdersTestFixture ordersTestFixture)
        {

        }

        [Fact]
        public async void AddOrderInitialized_Test()
        {
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<PriorityDbContext>();
            optionsBuilder.UseInMemoryDatabase("Test1");
            var dbContext = new PriorityDbContext(optionsBuilder.Options);

            WeekContainer container = new(WeekContainerTestFixture.GetDbWorkWeek(), new OrderScheduler(), dbContext);

            //Act
            await container.AddOrderInitialized(new OrderContainer(ManageOrdersTestFixture.GetPrioListElement()));

            //Assert
            Assert.Single(container.Orders);
            Assert.Equal(48, container.Week.CalendarWeek);
            Assert.Equal(14440, container.ProductionMinutes);
            Assert.Equal(3500, container.MinutesBooked);
            Assert.Single(container.Scheduler.Orders);
        }

        [Fact]
        public async void AddOrderAfterDragDrop_OrderNotAlreadyExists_AddOrder_Test()
        {
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<PriorityDbContext>();
            optionsBuilder.UseInMemoryDatabase("Test2");
            var dbContext = new PriorityDbContext(optionsBuilder.Options);

            var scheduler = new OrderScheduler();
            scheduler.AddOrder(new OrderContainer(new PrioListElement() { CWPlanned = 49, DeliveryDate = new DateTime(2021, 12, 9), OrderNr = "A001", Project = "P1", TimeTotal = 3500 }));
            dbContext.Orders.Add(new Order() { CurrentCW = 49, DeliveryDate = new DateTime(2021, 12, 9), TimeTotal = 3500, Key = "P1: A001" });

            WeekContainer container = new(WeekContainerTestFixture.GetDbWorkWeek(), scheduler, dbContext);
            
            //Act
            await container.AddOrderAfterDragDrop("P1: A001", true);

            //Assert
            Assert.Single(container.Orders);
            Assert.Equal(48, scheduler.Orders.First().CurrentCW);
        }

        [Fact]
        public async void AddOrderAfterDragDrop_OrderAlreadyExists_OrderNotAdded_Test()
        {
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<PriorityDbContext>();
            optionsBuilder.UseInMemoryDatabase("Test3");
            var dbContext = new PriorityDbContext(optionsBuilder.Options);

            var scheduler = new OrderScheduler();

            WeekContainer container = new(WeekContainerTestFixture.GetDbWorkWeek(), scheduler, dbContext);
            await container.AddOrderInitialized(new OrderContainer(ManageOrdersTestFixture.GetPrioListElement()));

            //Act
            await container.AddOrderAfterDragDrop("P1: A001", true);

            //Assert
            Assert.Single(container.Orders);
        }

        [Fact]
        public async void RemoveOrder_Test()
        {
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<PriorityDbContext>();
            optionsBuilder.UseInMemoryDatabase("Test3");
            var dbContext = new PriorityDbContext(optionsBuilder.Options);

            var scheduler = new OrderScheduler();

            WeekContainer container = new(WeekContainerTestFixture.GetDbWorkWeek(), scheduler, dbContext);
            await container.AddOrderInitialized(new OrderContainer(ManageOrdersTestFixture.GetPrioListElement()));

            scheduler.Orders.First().CurrentCW = 47;

            //Act
            await container.RemoveOrder();

            //Assert
            Assert.Empty(container.Orders);
        }
    }
}
