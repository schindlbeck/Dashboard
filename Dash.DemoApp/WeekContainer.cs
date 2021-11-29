using Dash.Data.Models;
using Dash.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dash.DemoApp.UserControls;

namespace Dash.DemoApp
{
    public class WeekContainer
    {
        public DbWorkWeek Week { get; set; }
        public List<OrderControl> Orders { get; set; }
        public OrderScheduler Scheduler { get; set; }

        public WeekContainer(DbWorkWeek week, OrderScheduler scheduler)
        {
            Week = week;
            Orders = new();
            Scheduler = scheduler;
        }

        public OrderControl AddOrder(string key)
        {
            if (!Orders.Exists(o => o.OrderContainer.ListElement.KeyToString().Equals(key)))
            {
                Scheduler.ChangeCW(key, Week.CalendarWeek);
                var order = Scheduler.GetOrder(key);
                order.SetCWCurrent(order.OrderContainer.CurrentCW);
                Orders.Add(order);

                return order;
            }
            return null;
        }

        public void RemoveOrder()
        {
            var schedulerOrders = Scheduler.Orders.Where(o => o.OrderContainer.CurrentCW == Week.CalendarWeek).ToList();

            var order = Orders.Except(schedulerOrders).FirstOrDefault();

            if (order is not null)
                Orders.Remove(order);
        }
    }
}
