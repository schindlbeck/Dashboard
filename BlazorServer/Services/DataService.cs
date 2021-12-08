using BlazorServer.Models;
using Dash.Data;
using Dash.Shared;
using System.Data.Entity;
using System.Threading.Tasks;

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

           Initialize();
        }


        public List<int> CalendarWeeks { get; internal set; } = new();

        private void Initialize()
        {
            //TODO : Configuration Enviroment Appsettings
            DataModels = ManageOrders.GetOrders(ManageOrders.GetPrioList(_configuration["ConnectionStrings:DefaultExcelFileConnection"], _configuration["Files:DefaultExcelFile"]));

            //TODO : Db data not in service, no async
            var weeks = DbContext.WorkWeeks.
                OrderBy(w => w.Year).
                ThenBy(w => w.CalendarWeek.ToString()).
                Select(w => w.CalendarWeek).ToList();
            
            CalendarWeeks.AddRange(weeks);
        }
    }
}
