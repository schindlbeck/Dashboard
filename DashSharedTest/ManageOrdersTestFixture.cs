using Dash.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DashSharedTest
{
    public class ManageOrdersTestFixture : IDisposable
    {
        public ManageOrdersTestFixture()
        {

        }

        public void Dispose()
        {
            
        }

        public static List<PrioListElement> GetPrioList()
        {
            PrioListElement[] elementArray = new[]
            {
                new PrioListElement() { DeliveryCW = 48, DeliveryDate = new DateTime(2021, 12, 2), OrderNr = "A001", Project = "P1" },
                new PrioListElement() { DeliveryCW = 48, DeliveryDate = new DateTime(2021, 12, 2), OrderNr = "A002", Project = "P2" },
                new PrioListElement() { DeliveryCW = 49, DeliveryDate = new DateTime(2021, 12, 9), OrderNr = "A003", Project = "P3" },
                new PrioListElement() { DeliveryCW = 50, DeliveryDate = new DateTime(2021, 12, 16), OrderNr = "A004", Project = "P4" },
                new PrioListElement() { DeliveryCW = 50, DeliveryDate = new DateTime(2021, 12, 16), OrderNr = "A005", Project = "P5" }
            };

            return elementArray.ToList(); 
        }

        public static PrioListElement GetPrioListElement()
        {
            return new PrioListElement() { DeliveryCW = 48, DeliveryDate = new DateTime(2021, 12, 2), OrderNr = "A001", Project = "P1", TimeTotal = 3500 };
        }

        public static List<PrioListElement> GetPrioListElementTheory()
        {
            PrioListElement[] elementArray = new[]
           {
                new PrioListElement() { DeliveryCW = 48, DeliveryDate = new DateTime(2021, 12, 2), OrderNr = "A001", Project = "P1", TimeTotal = 3500 },
                new PrioListElement() { DeliveryCW = 50, DeliveryDate = new DateTime(2021, 12, 16), OrderNr = "A002", Project = "P2", TimeTotal = 3500 },
                new PrioListElement() { DeliveryCW = 49, DeliveryDate = new DateTime(2021, 12, 9), OrderNr = "A003", Project = "P3", TimeTotal = 3500 },
                new PrioListElement() { DeliveryCW = 51, DeliveryDate = new DateTime(2021, 12, 23), OrderNr = "A004", Project = "P4", TimeTotal = 3500 },
                new PrioListElement() { DeliveryCW = 2, DeliveryDate = new DateTime(2022, 1, 12), OrderNr = "A005", Project = "P5", TimeTotal = 3500 }
            };

            return elementArray.ToList();
        }

        public static List<Order> GetOrders()
        {
            Order[] orderArray = new[]
            {
                new Order() { ProductionCW = 47, DeliveryDate = new DateTime(2021, 12, 2), Key = "P2: A002"},
                new Order() { ProductionCW = 49, DeliveryDate = new DateTime(2021, 12, 16), Key = "P4: A004"}
            };

            return orderArray.ToList();
        }

    }
}
