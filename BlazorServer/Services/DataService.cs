using BlazorServer.Models;
using Dash.Data;
using Dash.Shared;

namespace BlazorServer.Services
{
    public class DataService
    {
        public List<OrderContainer> DataModels = new();
        public DashDbContext DbContext { get; set; }

        public DataService(DashDbContext context)
        {
            DbContext = context;
            var sepp = DbContext.WorkWeeks.ToList();

            Initialize();
        }

        public List<int> CalendarWeeks { get; internal set; } = new();

        private void Initialize()
        {

            //DataModels.Add(new DataModel { Id = 1, Name = "Blau", Cw = 1 });
            //DataModels.Add(new DataModel { Id = 2, Name = "Rot", Cw = 2 });
            //DataModels.Add(new DataModel { Id = 3, Name = "Gelb", Cw = 3 });
            //DataModels.Add(new DataModel { Id = 4, Name = "Grün", Cw = 4 });
            //DataModels.Add(new DataModel { Id = 5, Name = "Lila", Cw = 5 });

            DataModels.Add(new OrderContainer(new PrioListElement { DeliveryDate = new DateTime(2021, 12, 08), Project = "A1", OrderNr = "a1", TimeTotal = 3500 }));
            DataModels.Add(new OrderContainer(new PrioListElement { DeliveryDate = new DateTime(2021, 12, 15), Project = "A2", OrderNr = "a2", TimeTotal = 3500 }));
            DataModels.Add(new OrderContainer(new PrioListElement { DeliveryDate = new DateTime(2021, 12, 08), Project = "A3", OrderNr = "a3", TimeTotal = 3500 }));



            //TODO : Models -> Orders from Excel
            //DataModels = ManageOrders.GetOrders(ManageOrders.GetPrioList());

            var weeks = DbContext.WorkWeeks.Select(w => w.CalendarWeek).Distinct().ToList();

            CalendarWeeks.AddRange(weeks);
        }
    }
}
