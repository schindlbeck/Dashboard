using BlazorServer.Models;
using Dash.Data;
using Dash.Shared;

namespace BlazorServer.Services
{
    public class DataService
    {
        public List<OrderContainer> DataModels = new();
        public DashDbContext DbContext { get; set; }
        private IConfiguration _configuration;

        public DataService(DashDbContext context, IConfiguration configuration)
        {
            DbContext = context;
            _configuration = configuration;
            var sepp = DbContext.WorkWeeks.ToList();

            Initialize();
        }

        public List<int> CalendarWeeks { get; internal set; } = new();

        private void Initialize()
        {
            DataModels.Add(new OrderContainer(new PrioListElement { DeliveryDate = new DateTime(2021, 12, 08), Project = "A1", OrderNr = "a1", TimeTotal = 3500 }));
            DataModels.Add(new OrderContainer(new PrioListElement { DeliveryDate = new DateTime(2021, 12, 15), Project = "A2", OrderNr = "a2", TimeTotal = 3500 }));
            DataModels.Add(new OrderContainer(new PrioListElement { DeliveryDate = new DateTime(2021, 12, 08), Project = "A3", OrderNr = "a3", TimeTotal = 3500 }));

            //TODO : Models -> Orders from Excel
            //DataModels = ManageOrders.GetOrders(ManageOrders.GetPrioList(_configuration["ConnectionStrings:DefaultExcelFileConnection"], _configuration["Files:DefaultExcelFile"]));

            //TODO: whats the problem?!!??!?!?!
            var weeks = DbContext.WorkWeeks.
                //OrderBy(w => Convert.ToInt32(w.Year.ToString() + w.CalendarWeek.ToString("00"))).
                Select(w => w.CalendarWeek).ToList();
            
            CalendarWeeks.AddRange(weeks);
        }
    }
}
