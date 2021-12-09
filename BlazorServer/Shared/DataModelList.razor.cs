using BlazorServer.Models;
using Dash.Data;
using Dash.Data.Models;
using Dash.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Shared
{
    public partial class DataModelList
    {
        [CascadingParameter] public DataModelContainer Container { get; set; }
        [Parameter] public TaskState State { get; set; }
        [Parameter] public TaskState[] AllowedStates { get; set; }
        [Parameter] public int CalendarWeek { get; set; }

        [Parameter] public DbWorkWeek Week {get; set; }

        readonly List<OrderContainer> Models = new();
        string dropClass = string.Empty;
        string dropZone = "dropzone ";

        protected override void OnParametersSet()
        {
            Models.Clear();

            switch (State)
            {
                case TaskState.Scheduled:
                    Models.AddRange(Container.Models.Where(x => x.State == State && CalendarWeek == x.ProductionCW));
                    break;

                default:
                    Models.AddRange(Container.Models.Where(x => x.State == State));
                    dropZone = "dropzonenew ";
                    break;
            }

            if(CalendarWeek != 0)
            Week = service.Weeks.First(w => w.CalendarWeek == CalendarWeek);
        }


        private void HandleDragEnter()
        {
            if (State == Container.Payload.State) return;

            if (AllowedStates != null && !AllowedStates.Contains(Container.Payload.State))
            {
                dropClass = "no-drop";
            }
            else
            {
                dropClass = "can-drop";
            }
        }

        private void HandleDragLeave()
        {
            dropClass = "";
        }

        private async Task HandleDrop()
        {
            var dataModel = Container.Payload;
            dropClass = "";
            if (AllowedStates != null && !AllowedStates.Contains(dataModel.State)) return;

            await Container.UpdateOrderAsync(State, CalendarWeek);

            await UpdateDatabase(dataModel);
        }

        private async Task UpdateDatabase(OrderContainer dataModel)
        {
            var element = dbContext.PriotizedOrders.FirstOrDefault(o => o.Key.Equals(dataModel.ListElement.KeyToString()));

            if (element is not null)
                await ChangeOrderInDb(dataModel);
            else
                await AddOrderToDbAsync(dataModel);
        }

        private async Task AddOrderToDbAsync(OrderContainer dataModel)
        {
            var dbOrder = new Order() { Key = dataModel.ListElement.KeyToString(), DeliveryDate = dataModel.ListElement.DeliveryDate, ProductionCW = CalendarWeek, TimeTotal = dataModel.ListElement.TimeTotal};
            dbContext.PriotizedOrders.Add(dbOrder);

            await dbContext.SaveChangesAsync();
        }

        private async Task ChangeOrderInDb(OrderContainer dataModel)
        {
            dbContext.PriotizedOrders.First(o => o.Key.Equals(dataModel.ListElement.KeyToString())).ProductionCW = Week.CalendarWeek;

            await dbContext.SaveChangesAsync();
        }

    }
}
