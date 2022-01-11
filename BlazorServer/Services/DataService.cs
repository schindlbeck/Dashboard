using Dash.Data;
using Dash.Data.Models;
using Dash.Shared;

namespace BlazorServer.Services
{
    public class DataService
    {
        public List<OrderContainer> DataModels = new();
        public DashDbContext DbContext { get; set; }
        private readonly IConfiguration _configuration;

        public DataService(DashDbContext context, IConfiguration configuration)
        {
            DbContext = context;
            _configuration = configuration;

           Initialize();
        }

        public List<int> CalendarWeeks { get; internal set; } = new();
        public List<DbWorkWeek> Weeks { get; internal set; } = new();

        private void Initialize()
        {
            DataModels = ManageOrders.GetOrders(ManageOrders.GetPrioList(_configuration["ConnectionStrings:DefaultExcelFileConnection"], _configuration["Files:DefaultExcelFile"]));

            CheckDataModelsState();

            Weeks = GetWeeksDisplayed();

            var calendarWeeks = Weeks.
                OrderBy(w => w.Year).
                ThenBy(w => w.CalendarWeek).
                Select(w => w.CalendarWeek).ToList();

            CalendarWeeks.AddRange(calendarWeeks);
        }

        private void CheckDataModelsState()
        {
            var prioritizedOrders = DbContext.PriotizedOrders.ToList();

            foreach (var order in DataModels)
            {
                if (prioritizedOrders.Exists(o => o.Key.Equals(order.ListElement.KeyToString())))
                {
                    var productionCW = prioritizedOrders.First(o => o.Key.Equals(order.ListElement.KeyToString())).ProductionCW;

                    order.ProductionCW = productionCW;
                    order.State = TaskState.Scheduled;
                }
            }
        }

        private List<DbWorkWeek> GetWeeksDisplayed()
        {
            //TODO : Db data not in service, no async
            var weeks = DbContext.WorkWeeks.ToList();

            //TODO : cw later dateNow
            var currentCw = 41;
            var currentYear = 2021;

            //later other source
            var prioListWeeks = DataModels.Select(w => Convert.ToInt32($"{w.ListElement.DeliveryDate.Year}{w.ListElement.DeliveryCW}")).ToList();

            var weeksDisplayed = weeks.Where(w => (w.CalendarWeek >= currentCw && w.Year == currentYear)
                                                                || w.Year > currentYear
                                                                || prioListWeeks.Contains(Convert.ToInt32($"{w.Year}{w.CalendarWeek}")))
                                                                .ToList();
            return weeksDisplayed;
        }
    }
}
