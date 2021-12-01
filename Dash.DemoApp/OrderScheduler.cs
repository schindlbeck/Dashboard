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
        public List<OrderControl> Orders { get; private set; }
        private readonly PriorityDbContext priorityDbContext;

        private readonly Stack<LastChangedItem> lastChanged = new();

        public OrderScheduler(PriorityDbContext priorityDbContext)
        {
            Orders = new();
            this.priorityDbContext = priorityDbContext;
        }

        public void AddOrder(OrderControl order)
        {
            Orders.Add(order); 
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

        public async Task ChangeCW(string key, int newWeek, int year, bool isUndo)
        {
            var oldWeek = Orders.First(o => o.OrderContainer.ListElement.KeyToString().Equals(key)).OrderContainer.CurrentCW;
            Orders.First(o => o.OrderContainer.ListElement.KeyToString().Equals(key)).OrderContainer.CurrentCW = newWeek;
            Orders.First(o => o.OrderContainer.ListElement.KeyToString().Equals(key)).OrderContainer.CurrentYear = year;

            priorityDbContext.Orders.First(o => o.Key.Equals(key)).CurrentCW = newWeek;
            await priorityDbContext.SaveChangesAsync();

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
