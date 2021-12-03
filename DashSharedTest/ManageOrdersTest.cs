using Dash.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DashSharedTest
{
    public class ManageOrdersTest : IClassFixture<ManageOrdersTestFixture>
    {
        public ManageOrdersTest(ManageOrdersTestFixture prioListFixture)
        {

        }

        [Fact]
        public void GetPrioList_Test()
        {
            //Arrange


            //Act


            //Assert
        }

        [Fact]
        public void GetOrders_Test()
        {
            //Act
            var orders = ManageOrders.GetOrders(ManageOrdersTestFixture.GetPrioList());

            //Assert
            Assert.Equal(5, orders.Count);

            Assert.Equal(48, orders[0].CurrentCW);
            Assert.Equal(50, orders[3].CurrentCW);

            Assert.Equal(2021, orders[1].CurrentYear);

            Assert.Equal(ManageOrdersTestFixture.GetPrioList()[2].Project, orders[2].ListElement.Project);

        }

        [Fact]
        public void CheckOrdersAgainstPrioritization()
        {
            //Arrange
            var orders = ManageOrders.GetOrders(ManageOrdersTestFixture.GetPrioList());

            //Act
            var result = ManageOrders.CheckOrdersAgainstPrioritization(orders, ManageOrdersTestFixture.GetOrders());

            //Assert
            Assert.Equal(5, result.Count);
            Assert.Equal(48, result[0].CurrentCW);
            Assert.Equal(47, result[1].CurrentCW);
            Assert.Equal(49, result[2].CurrentCW);
            Assert.Equal(49, result[3].CurrentCW);
            Assert.Equal(50, result[4].CurrentCW);

        }
    }
}
