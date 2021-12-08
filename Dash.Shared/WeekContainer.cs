using Dash.Data;
using Dash.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dash.Shared
{
    public class WeekContainer
    {
        public DbWorkWeek Week { get; private set; }

        public List<OrderContainer> Orders { get; private set; }
        public OrderScheduler Scheduler { get; set; }

        public int ProductionMinutes { get { return Week.ProductionMinutes; } }

        public int MinutesBooked { get { return Orders.Sum(s => s.ListElement.TimeTotal); } }

        private readonly DashDbContext dbContext;

        public WeekContainer(DbWorkWeek week, OrderScheduler scheduler, DashDbContext dbContext)
        {
            Week = week;
            Orders = new();
            Scheduler = scheduler;
            this.dbContext = dbContext;
        }

        public async Task AddOrderInitialized(OrderContainer order)
        {
            Scheduler.AddOrder(order);
            Orders.Add(order);
            var dbOrder = new Order() { DeliveryDate = order.ListElement.DeliveryDate, Key = order.ListElement.KeyToString(), TimeTotal = order.ListElement.TimeTotal, ProductionCW = Week.CalendarWeek };

            if (dbContext.PriotizedOrders.Contains(dbOrder))
                await ChangeOrderInDb(dbOrder);
            else
                await AddOrderToDbAsync(dbOrder);
        }

        public async Task<OrderContainer> AddOrderAfterDragDrop(string key, bool isUndo)
        {
            if (!Orders.Exists(o => o.ListElement.KeyToString().Equals(key)))
            {
                var order = await ChangeProductionCW(key, isUndo);

                Orders.Add(order);

                return order;
            }
            return null;
        }

        private async Task<OrderContainer> ChangeProductionCW(string key, bool isUndo)
        {
            Scheduler.ChangeProductionCW(key, Week.CalendarWeek, Week.Year, isUndo);
            var order = Scheduler.GetOrder(key);

            order.ProductionCWChanged();

            await ChangeProductionCWInDb(key);

            return order;
        }

        public void RemoveOrder()
        {
            var schedulerOrders = Scheduler.Orders.Where(o => o.ProductionCW == Week.CalendarWeek).ToList();

            var removedOrder = Orders.Except(schedulerOrders).FirstOrDefault();

            if (removedOrder is not null)
            {
                Orders.Remove(removedOrder);
            }
        }

        private async Task ChangeProductionCWInDb(string key)
        {
            dbContext.PriotizedOrders.First(o => o.Key.Equals(key)).ProductionCW = Week.CalendarWeek;
            await dbContext.SaveChangesAsync();
        }

        internal async Task AddOrderToDbAsync(Order dbOrder)
        {
            dbContext.PriotizedOrders.Add(dbOrder);

            await dbContext.SaveChangesAsync();
        }

        private async Task ChangeOrderInDb(Order dbOrder)
        {
            dbContext.PriotizedOrders.First(o => o.Key == dbOrder.Key).ProductionCW = Week.CalendarWeek;

            await dbContext.SaveChangesAsync();
        }


    }
}
