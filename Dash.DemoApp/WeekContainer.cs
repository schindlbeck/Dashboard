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

        //TODO : OrderConatainer
        public List<OrderControl> Orders { get; private set; }
        public OrderScheduler Scheduler { get; set; }

        private readonly PriorityDbContext dbContext;

        public WeekContainer(DbWorkWeek week, OrderScheduler scheduler, PriorityDbContext dbContext)
        {
            Week = week;
            Orders = new();
            Scheduler = scheduler;
            this.dbContext = dbContext;
            dbContext.Database.EnsureCreated();

            AddWeekToDb();
        }

        private async void AddWeekToDb()
        {
            dbContext.Weeks.Add(new Week() { CalendarWeek = Week.CalendarWeek, ProductionMinutes = Week.ProductionMinutes, Year = Week.Year, Orders = new() });
            await dbContext.SaveChangesAsync();
        }

        public async Task AddOrderInitialized(OrderControl order)
        {
            Scheduler.AddOrder(order);
            Orders.Add(order);
            var dbOrder = new Order() { DeliveryDate = order.OrderContainer.ListElement.DeliveryDate, Key = order.OrderContainer.ListElement.KeyToString(), TimeTotal = order.OrderContainer.ListElement.TimeTotal, CurrentCW = Week.CalendarWeek };

            await AddOrderToDbAsync(dbOrder);

        }

        //TODO : OrderContainer instead of OrderControl
        public async Task<OrderControl> AddOrderAfterDragDrop(string key, bool isUndo)
        {
            if (!Orders.Exists(o => o.OrderContainer.ListElement.KeyToString().Equals(key)))
            {
                await Scheduler.ChangeCW(key, Week.CalendarWeek, Week.Year, isUndo);
                var order = Scheduler.GetOrder(key);
                order.SetCWCurrent();
                Orders.Add(order);

                dbContext.Orders.First(o => o.Key.Equals(key)).CurrentCW = Week.CalendarWeek;
                await dbContext.SaveChangesAsync();

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

        public async Task RemoveOrder()
        {
            var schedulerOrders = Scheduler.Orders.Where(o => o.OrderContainer.CurrentCW == Week.CalendarWeek).ToList();

            var order = Orders.Except(schedulerOrders).FirstOrDefault();

            if (order is not null)
            {
                Orders.Remove(order);
                var removedOrder = dbContext.Weeks.First(w => w.CalendarWeek == Week.CalendarWeek).Orders.FirstOrDefault(o => order.OrderContainer.ListElement.KeyToString().Equals(o.Key));
                dbContext.Weeks.First(w => w.CalendarWeek == Week.CalendarWeek).Orders.Remove(removedOrder);

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
