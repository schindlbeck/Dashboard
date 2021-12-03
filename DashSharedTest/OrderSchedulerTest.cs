using Dash.Data;
using Dash.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace DashSharedTest
{
    public class OrderSchedulerTest : IClassFixture<ManageOrdersTestFixture>
    {
        public OrderSchedulerTest(ManageOrdersTestFixture prioListFixture)
        {

        }

        [Fact]
        public void AddOrder_Test()
        {
            //Arrange
            OrderScheduler scheduler = new();
            OrderContainer container = new(ManageOrdersTestFixture.GetPrioListElement());

            //Act
            scheduler.AddOrder(container);

            //Assert
            Assert.Equal(container, scheduler.Orders.First());
        }

        [Fact]
        public void GetOrder_Test()
        {
            //Arrange
            OrderScheduler scheduler = new();
            OrderContainer container = new(ManageOrdersTestFixture.GetPrioListElement());
            scheduler.AddOrder(container);

            //Act
            var result = scheduler.GetOrder(container.ListElement.KeyToString());

            //Assert
            Assert.Equal(container, result);

        }

        [Fact]
        public void ChangeCW_Test()
        {
            //Arrange
            OrderScheduler scheduler = new();
            OrderContainer container = new(ManageOrdersTestFixture.GetPrioListElement());
            scheduler.AddOrder(container);

            //Act
            scheduler.ChangeCW(container.ListElement.KeyToString(), 47, 2021, true);

            //Assert
            Assert.Equal(47, scheduler.Orders.First().CurrentCW);
        }

        [Fact]
        public void AddLastChangedItem_Test()
        {
            //Arrange
            OrderScheduler scheduler = new();
            OrderContainer container = new(ManageOrdersTestFixture.GetPrioListElement());
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
            OrderScheduler scheduler = new();
            OrderContainer container = new(ManageOrdersTestFixture.GetPrioListElement());
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
            OrderScheduler scheduler = new();
            OrderContainer container = new(ManageOrdersTestFixture.GetPrioListElement());
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
            OrderScheduler scheduler = new();
            OrderContainer container = new(ManageOrdersTestFixture.GetPrioListElement());
            scheduler.AddOrder(container);
            scheduler.AddLastChangedItem(container.ListElement.KeyToString(), 48, 47);

            //Act
            scheduler.LastChangedUndid();

            //Assert
            Assert.Empty(scheduler.lastChanged);
        }

        
    }
}
