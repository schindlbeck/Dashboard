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

        [Theory]
        [InlineData(47, 2021, true, 0)]
        [InlineData(48, 2021, true, 1)]
        [InlineData(48, 2021, true, 2)]
        [InlineData(1, 2022, true, 3)]
        [InlineData(5, 2022, true, 4)]
        public void ChangeProductionCW_IsUndo_Theory(int newcw, int year, bool isUndo, int priolistElementindex)
        {
            //Arrange
            OrderScheduler scheduler = new();
            var prioListElement = ManageOrdersTestFixture.GetPrioListElementTheory()[priolistElementindex];
            OrderContainer container = new(prioListElement);
            scheduler.AddOrder(container);

            //Act
            scheduler.ChangeProductionCW(container.ListElement.KeyToString(), newcw, year, isUndo);

            //Assert
            Assert.Equal(newcw, scheduler.Orders.First().ProductionCW);
        }

        [Theory]
        [InlineData(47, 2021, false, 0)]
        [InlineData(48, 2021, false, 1)]
        [InlineData(48, 2021, false, 2)]
        [InlineData(1, 2022, false, 3)]
        [InlineData(5, 2022, false, 4)]
        public void ChangeProductionCW_IsNotUndo_Theory(int newcw, int year, bool isUndo, int priolistElementindex)
        {
            //Arrange
            OrderScheduler scheduler = new();
            var prioListElement = ManageOrdersTestFixture.GetPrioListElementTheory()[priolistElementindex];
            OrderContainer container = new(prioListElement);
            scheduler.AddOrder(container);

            //Act
            scheduler.ChangeProductionCW(container.ListElement.KeyToString(), newcw, year, isUndo);
            var resultLastChanged = scheduler.lastChanged.Peek();

            //Assert
            Assert.Equal(newcw, scheduler.Orders.First().ProductionCW);

            if (!isUndo)
            {
                Assert.Equal(prioListElement.KeyToString(), resultLastChanged.Key);
                Assert.Equal(prioListElement.DeliveryCW, resultLastChanged.OldProdutionCW);
                Assert.Equal(newcw, resultLastChanged.NewProductionCW);
            }
        }

        [Fact]
        public void GetLastChangedItem_LastChangedItemExists_GetItem_Test()
        {
            //Arrange
            OrderScheduler scheduler = new();
            OrderContainer container = new(ManageOrdersTestFixture.GetPrioListElement());
            scheduler.AddOrder(container);
            scheduler.ChangeProductionCW(container.ListElement.KeyToString(), 47, 2021, false);

            //Act
            var result = scheduler.GetLastChangedItem();

            //Assert
            Assert.Equal(47, result.NewProductionCW);
            Assert.Equal(48, result.OldProdutionCW);
            Assert.Equal(container.ListElement.KeyToString(), result.Key);
        }

        [Fact]
        public void GetLastChangedItem_NoLastChangedItemExists_null_Test()
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
            scheduler.ChangeProductionCW(container.ListElement.KeyToString(), 47, 2021, false);

            //Act
            scheduler.LastChangedUndid();

            //Assert
            Assert.Empty(scheduler.lastChanged);
        }

    }
}
