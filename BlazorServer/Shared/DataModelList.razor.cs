using BlazorServer.Models;
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

        List<OrderContainer> Models = new();
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
            dropClass = "";
            if (AllowedStates != null && !AllowedStates.Contains(Container.Payload.State)) return;

            await Container.UpdateOrderAsync(State, CalendarWeek);
        }

    }
}
