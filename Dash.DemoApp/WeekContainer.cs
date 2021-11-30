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

        private PriorityDbContext dbContext;

        public WeekContainer(DbWorkWeek week, OrderScheduler scheduler, PriorityDbContext dbContext)
        {
            Week = week;
            Orders = new();
            Scheduler = scheduler;
            this.dbContext = dbContext;
            dbContext.Database.EnsureCreated();

            AddToDb();
        }

        private void AddToDb()
        {
            dbContext.Weeks.Add(new Week() { CalendarWeek = Week.CalendarWeek, ProductionMinutes = Week.ProductionMinutes, Year = Week.Year, Orders = new() });
            dbContext.SaveChangesAsync();
        }

        public async Task<OrderControl> AddOrder(string key, bool isUndo)
        {
            if (!Orders.Exists(o => o.OrderContainer.ListElement.KeyToString().Equals(key)))
            {
                Scheduler.ChangeCW(key, Week.CalendarWeek, Week.Year, isUndo);
                var order = Scheduler.GetOrder(key);
                order.SetCWCurrent();
                Orders.Add(order);

                var dbOrder = new Order() { DeliveryDate = order.OrderContainer.ListElement.DeliveryDate, Key = key, TimeTotal = order.OrderContainer.ListElement.TimeTotal };
                await AddOrderToDbAsync(dbOrder);

                return order;
            }
            return null;
        }

        private async Task AddOrderToDbAsync(Order dbOrder)
        {
            dbContext.Orders.Add(dbOrder);
            dbContext.Weeks.First(w => w.CalendarWeek == Week.CalendarWeek && w.Year == Week.Year).Orders.Add(dbOrder);

            await dbContext.SaveChangesAsync();
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
