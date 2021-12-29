using Dash.Shared;

namespace BlazorServer.Pages
{
    public partial class DragDrop
    {
        List<OrderContainer> DataModels = new();
        readonly List<int> CalendarWeeks = new();
        string lastTask = string.Empty;

        protected override void OnInitialized()
        {
            DataModels = service.DataModels;
            CalendarWeeks.AddRange(service.CalendarWeeks);
        }
        void HandleStateUpdate(OrderContainer model)
        {
            lastTask = model.ListElement.KeyToString();
        }
    }
}
