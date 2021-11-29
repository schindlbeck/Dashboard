using Dash.Data;
using Dash.DemoApp.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dash.DemoApp
{
    public class OrderScheduler
    {
        public List<OrderControl> Orders;

        private readonly Stack<LastChangedItem> lastChanged = new();

        public OrderScheduler()
        {
            Orders = new();

        }

        private void AddLastChangedItem(string key, int cwLast, int cwNow)
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

        public OrderControl GetOrder(string key)
        {
            return Orders.First(o => o.OrderContainer.ListElement.KeyToString().Equals(key));
        }

        public void ChangeCW(string key, int newWeek, bool isUndo)
        {
            var oldWeek = Orders.First(o => o.OrderContainer.ListElement.KeyToString().Equals(key)).OrderContainer.CurrentCW;
            Orders.First(o => o.OrderContainer.ListElement.KeyToString().Equals(key)).OrderContainer.CurrentCW = newWeek;

            if (!isUndo)
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
