using Dash.Data;
using Dash.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dash.Shared
{
    public class WeekContainer
    {
        public DbWorkWeek Week { get; set; }

        public List<OrderContainer> Orders { get; private set; }
        public OrderScheduler Scheduler { get; set; }

        public int ProductionMinutes { get { return Week.ProductionMinutes; } }
        
        public int MinutesBooked { get { return Orders.Sum(s => s.ListElement.TimeTotal); } }

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

        public async Task AddOrderInitialized(OrderContainer order)
        {
            Scheduler.AddOrder(order);
            Orders.Add(order);
            var dbOrder = new Order() { DeliveryDate = order.ListElement.DeliveryDate, Key = order.ListElement.KeyToString(), TimeTotal = order.ListElement.TimeTotal, CurrentCW = Week.CalendarWeek };

            await AddOrderToDbAsync(dbOrder);
        }

        public async Task<OrderContainer> AddOrderAfterDragDrop(string key, bool isUndo)
        {
            if (!Orders.Exists(o => o.ListElement.KeyToString().Equals(key)))
            {
                var order = await ChangeCurrentCw(key, isUndo);

                Orders.Add(order);

                return order;
            }
            return null;
        }

        private async Task<OrderContainer> ChangeCurrentCw(string key, bool isUndo)
        {
            Scheduler.ChangeCW(key, Week.CalendarWeek, Week.Year, isUndo);
            var order = Scheduler.GetOrder(key);

            order.CurrentCwChanged();

            await ChangeCurrentCwInDb(key);

            return order;
        }

        public async Task RemoveOrder()
        {
            var schedulerOrders = Scheduler.Orders.Where(o => o.CurrentCW == Week.CalendarWeek).ToList();

            var removedOrder = Orders.Except(schedulerOrders).FirstOrDefault();

            if (removedOrder is not null)
            {
                Orders.Remove(removedOrder);

                await RemoveOrderInDb(removedOrder);
            }
        }

        private async void AddWeekToDb()
        {
            dbContext.Weeks.Add(new Week() { CalendarWeek = Week.CalendarWeek, ProductionMinutes = Week.ProductionMinutes, Year = Week.Year, Orders = new() });
            await dbContext.SaveChangesAsync();
        }

        private async Task ChangeCurrentCwInDb(string key)
        {
            dbContext.Orders.First(o => o.Key.Equals(key)).CurrentCW = Week.CalendarWeek;
            await dbContext.SaveChangesAsync();
        }

        private async Task AddOrderToDbAsync(Order dbOrder)
        {
            dbContext.Orders.Add(dbOrder);
            dbContext.Weeks.First(w => w.CalendarWeek == Week.CalendarWeek && w.Year == Week.Year).Orders.Add(dbOrder);

            await dbContext.SaveChangesAsync();
        }

        private async Task RemoveOrderInDb(OrderContainer order)
        {
            var removedOrder = dbContext.Weeks.First(w => w.CalendarWeek == Week.CalendarWeek).Orders.FirstOrDefault(o => order.ListElement.KeyToString().Equals(o.Key));
            dbContext.Weeks.First(w => w.CalendarWeek == Week.CalendarWeek).Orders.Remove(removedOrder);

            await dbContext.SaveChangesAsync();
        }
    }
}
