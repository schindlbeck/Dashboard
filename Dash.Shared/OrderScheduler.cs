using Dash.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dash.Shared
{
    public class OrderScheduler
    {
        public List<OrderContainer> Orders;

        private Stack<OrderContainer> lastChanged = new();

        public OrderScheduler(List<PrioListElement> prioList)
        {
            foreach(PrioListElement prio in prioList)
            {
                Orders.Add(new OrderContainer(prio));
            }
        }

        public void AddLastChangedItem(string Key)
        {
            lastChanged.Push(Orders.First(o => o.ListElement.KeyToString() == Key));
        }

        public string GetLastChangedItem()
        {
            return lastChanged.Peek().ListElement.KeyToString();
        }

        public void LastChangedUndid()
        {
            lastChanged.Pop();
        }

        

    }
}
