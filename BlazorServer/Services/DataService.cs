using BlazorServer.Models;
using Dash.Data;

namespace BlazorServer.Services
{
    public class DataService
    {
        public List<DataModel> DataModels = new();
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
            DataModels.Add(new DataModel { Id = 1, Name = "Blau", Cw = 1 });
            DataModels.Add(new DataModel { Id = 2, Name = "Rot", Cw = 2 });
            DataModels.Add(new DataModel { Id = 3, Name = "Gelb", Cw = 3 });
            DataModels.Add(new DataModel { Id = 4, Name = "Grün", Cw = 4 });
            DataModels.Add(new DataModel { Id = 5, Name = "Lila", Cw = 5 });

            var weeks = DbContext.WorkWeeks.Select(w => w.CalendarWeek).Distinct().ToList();

            CalendarWeeks.AddRange(weeks);
        }
    }
}
