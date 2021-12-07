using BlazorServer.Models;
using Dash.Data;
using Dash.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Pages
{
    public partial class DragDrop
    {
        List<OrderContainer> DataModels = new();
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
