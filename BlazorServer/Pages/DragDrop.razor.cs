using BlazorServer.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Pages
{
    public partial class DragDrop
    {
        List<DataModel> DataModels = new();
        List<int> CalendarWeeks = new();
        string lastTask = string.Empty;

        protected override void OnInitialized()
        {
            DataModels = service.DataModels;
            CalendarWeeks.AddRange(service.CalendarWeeks);
        }
        void HandleStateUpdate(DataModel model)
        {
            lastTask = model.Name;
        }
    }
}
