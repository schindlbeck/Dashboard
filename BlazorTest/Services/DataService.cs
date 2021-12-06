using BlazorTest.Models;

namespace BlazorTest.Services
{
    public class DataService
    {
        public List<DataModel> DataModels = new();

        public DataService()
        {
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

            CalendarWeeks.AddRange(DataModels.Select(dm => dm.Cw).OrderBy(w => w).Distinct());
        }
    }
}
