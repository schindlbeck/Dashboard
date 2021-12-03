using Dash.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dash.Shared

{
    public class OrderScheduler
    {
        public List<OrderContainer> Orders { get; private set; }
        internal readonly Stack<LastChangedItem> lastChanged = new();
        

        public OrderScheduler()
        {
            Orders = new();
        }

        public void AddOrder(OrderContainer order)
        {
            Orders.Add(order); 
        }

        public OrderContainer GetOrder(string key)
        {
            return Orders.First(o => o.ListElement.KeyToString().Equals(key));
        }

        public void ChangeCW(string key, int newWeek, int year, bool isUndo)
        {
            var oldWeek = Orders.First(o => o.ListElement.KeyToString().Equals(key)).CurrentCW;
            Orders.First(o => o.ListElement.KeyToString().Equals(key)).CurrentCW = newWeek;
            Orders.First(o => o.ListElement.KeyToString().Equals(key)).CurrentYear = year;


            if (!isUndo)
                AddLastChangedItem(key, oldWeek, newWeek);
        }

        internal void AddLastChangedItem(string key, int cwLast, int cwNow)
        {
            lastChanged.Push(new LastChangedItem() { Key = key, CwLast = cwLast, CwNow = cwNow });
        }

        public LastChangedItem GetLastChangedItem()
        {
            try
            {
                return lastChanged.Peek();
            }
            catch
            {
                return null;
            }
        }

        public void LastChangedUndid()
        {
            lastChanged.Pop();
        }
    }

    public class LastChangedItem
    {
        public string Key { get; set; }

        public int CwLast { get; set; }

        public int CwNow { get; set; }
    }
}
