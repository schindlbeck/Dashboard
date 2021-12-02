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
            Assert.Equal(container, scheduler.Orders.First());
        }

        [Fact]
        public void GetOrder_Test()
        {
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<PriorityDbContext>();
            optionsBuilder.UseInMemoryDatabase("Test6");
            var dbContext = new PriorityDbContext(optionsBuilder.Options);

            OrderScheduler scheduler = new(dbContext);
            PrioListElement element = new() { CWPlanned = 48, DeliveryDate = new DateTime(2021, 12, 2), OrderNr = "A001", Project = "P1" };
            OrderContainer container = new(element);
            scheduler.AddOrder(container);

            //Act
            var result = scheduler.GetOrder(container.ListElement.KeyToString());

            //Assert
            Assert.Equal(container, result);

        }

        [Fact]
        public async void ChangeCW_Test()
        {
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<PriorityDbContext>();
            optionsBuilder.UseInMemoryDatabase("Test7");
            var dbContext = new PriorityDbContext(optionsBuilder.Options);

            OrderScheduler scheduler = new(dbContext);
            PrioListElement element = new() { CWPlanned = 48, DeliveryDate = new DateTime(2021, 12, 2), OrderNr = "A001", Project = "P1" };
            OrderContainer container = new(element);
            scheduler.AddOrder(container);

            //Act
            await scheduler.ChangeCW(container.ListElement.KeyToString(), 47, 2021, true);

            //Assert
            Assert.Equal(47, scheduler.Orders.First().CurrentCW);
        }

        [Fact]
        public void AddLastChangedItem_Test()
        {
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<PriorityDbContext>();
            optionsBuilder.UseInMemoryDatabase("Test2");
            var dbContext = new PriorityDbContext(optionsBuilder.Options);

            OrderScheduler scheduler = new(dbContext);
            PrioListElement element = new() { CWPlanned = 48, DeliveryDate = new DateTime(2021, 12, 2), OrderNr = "A001", Project = "P1" };
            OrderContainer container = new(element);
            scheduler.AddOrder(container);


            //Act
            scheduler.AddLastChangedItem(container.ListElement.KeyToString(), 48, 47);

            //Assert
            Assert.Equal(47, scheduler.lastChanged.Peek().CwNow);
            Assert.Equal(48, scheduler.lastChanged.Peek().CwLast);
            Assert.Equal(container.ListElement.KeyToString(), scheduler.lastChanged.Peek().Key);

        }

        [Fact]
        public void GetLastChangedItem_Test()
        {
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<PriorityDbContext>();
            optionsBuilder.UseInMemoryDatabase("Test3");
            var dbContext = new PriorityDbContext(optionsBuilder.Options);

            OrderScheduler scheduler = new(dbContext);
            PrioListElement element = new() { CWPlanned = 48, DeliveryDate = new DateTime(2021, 12, 2), OrderNr = "A001", Project = "P1" };
            OrderContainer container = new(element);
            scheduler.AddOrder(container);
            scheduler.AddLastChangedItem(container.ListElement.KeyToString(), 48, 47);

            //Act
            var result = scheduler.GetLastChangedItem();

            //Assert
            Assert.Equal(47, result.CwNow);
            Assert.Equal(48, result.CwLast);
            Assert.Equal(container.ListElement.KeyToString(), result.Key);
        }

        [Fact]
        public void GetLastChangedItem_null_Test()
        {
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<PriorityDbContext>();
            optionsBuilder.UseInMemoryDatabase("Test4");
            var dbContext = new PriorityDbContext(optionsBuilder.Options);

            OrderScheduler scheduler = new(dbContext);
            PrioListElement element = new() { CWPlanned = 48, DeliveryDate = new DateTime(2021, 12, 2), OrderNr = "A001", Project = "P1" };
            OrderContainer container = new(element);
            scheduler.AddOrder(container);

            //Act
            var result = scheduler.GetLastChangedItem();

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void LastChangedUndid_Test()
        {
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<PriorityDbContext>();
            optionsBuilder.UseInMemoryDatabase("Test5");
            var dbContext = new PriorityDbContext(optionsBuilder.Options);

            OrderScheduler scheduler = new(dbContext);
            PrioListElement element = new() { CWPlanned = 48, DeliveryDate = new DateTime(2021, 12, 2), OrderNr = "A001", Project = "P1" };
            OrderContainer container = new(element);
            scheduler.AddOrder(container);
            scheduler.AddLastChangedItem(container.ListElement.KeyToString(), 48, 47);

            //Act
            scheduler.LastChangedUndid();

            //Assert
            Assert.Empty(scheduler.lastChanged);
        }

        
    }
}
