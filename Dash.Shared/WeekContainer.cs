using Dash.Data.Models;
using Dash.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dash.Shared
{
    public class WeekContainer
    {
        public DbWorkWeek Week { get; set; }
        public List<PrioListElement> Orders { get; set; }
        public OrderScheduler Scheduler { get; set; }

        public WeekContainer(DbWorkWeek week, OrderScheduler scheduler)
        {
            Week = week;
            Orders = new();
            Scheduler = scheduler;
        }

        public PrioListElement AddOrder()
        {
            if(!Orders.Exists(o => o.KeyToString().Equals(Scheduler.KeyDraggedOrder)))
            {
                var order = Scheduler.GetOrder(Scheduler.KeyDraggedOrder);
                Orders.Add(order.ListElement);

                return order.ListElement;
            }

            return null;
        }

        public void RemoveOrder()
        {

        }
    }
}
