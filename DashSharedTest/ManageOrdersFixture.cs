using Dash.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DashSharedTest
{
    public class ManageOrdersFixture : IDisposable
    {
        public ManageOrdersFixture()
        {

        }

        public void Dispose()
        {
            
        }

        public static List<PrioListElement> GetPrioList()
        {
            PrioListElement[] elementArray = new[]
            {
                new PrioListElement() { CWPlanned = 48, DeliveryDate = new DateTime(2021, 12, 2), OrderNr = "A001", Project = "P1" },
                new PrioListElement() { CWPlanned = 48, DeliveryDate = new DateTime(2021, 12, 2), OrderNr = "A002", Project = "P2" },
                new PrioListElement() { CWPlanned = 49, DeliveryDate = new DateTime(2021, 12, 9), OrderNr = "A003", Project = "P3" },
                new PrioListElement() { CWPlanned = 50, DeliveryDate = new DateTime(2021, 12, 16), OrderNr = "A004", Project = "P4" },
                new PrioListElement() { CWPlanned = 50, DeliveryDate = new DateTime(2021, 12, 16), OrderNr = "A005", Project = "P5" }
            };

            return elementArray.ToList(); 
        }

        public static PrioListElement GetPrioListElement()
        {
            return new PrioListElement() { CWPlanned = 48, DeliveryDate = new DateTime(2021, 12, 2), OrderNr = "A001", Project = "P1" };
        }

        public static List<Order> GetOrders()
        {
            Order[] orderArray = new[]
            {
                new Order() { CurrentCW = 47, DeliveryDate = new DateTime(2021, 12, 2), Key = "P2: A002"},
                new Order() { CurrentCW = 49, DeliveryDate = new DateTime(2021, 12, 16), Key = "P4: A004"}
            };

            return orderArray.ToList();
        }

    }
}
