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
        public string KeyDraggedOrder;

        private readonly Stack<LastChangedItem> lastChanged = new();

        public OrderScheduler(List<PrioListElement> prioList)
        {
            Orders = new();
            foreach (PrioListElement prio in prioList)
            {
                Orders.Add(new OrderContainer(prio));
            }
        }

        private void AddLastChangedItem(string key, int cwLast, int cwNow)
        {
            lastChanged.Push(new LastChangedItem() { Key = key, CwLast = cwLast, CwNow = cwNow });
        }

        public string GetLastChangedItem()
        {
            return lastChanged.Peek().Key;
        }

        public void LastChangedUndid()
        {
            lastChanged.Pop();
        }

        public OrderContainer GetOrder(string key)
        {
            return Orders.First(o => o.ListElement.KeyToString().Equals(key));
        }

        public void ChangeCW(string key, int newWeek)
        {
            var oldWeek = Orders.First(o => o.ListElement.KeyToString().Equals(key)).CurrentCW;

            Orders.First(o => o.ListElement.KeyToString().Equals(key)).CurrentCW = newWeek;
            AddLastChangedItem(key, oldWeek, newWeek);
        }
    }

    public class LastChangedItem
    {
        public string Key { get; set; }

        public int CwLast { get; set; }

        public int CwNow { get; set; }
    }
}
