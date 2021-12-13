using BlazorServer.Models;
using Dash.Data;
using Dash.Data.Models;
using Dash.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Shared
{
    public partial class DataModelContainer
    {
        [Parameter] public List<OrderContainer> Models { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public EventCallback<OrderContainer> OnStateUpdate { get; set; }
        [Parameter] public OrderContainer Payload { get; set; }

        public event EventHandler<OrderContainer> OnOrderUpdate;

        public async Task UpdateOrderAsync(TaskState newType, int cw)
        {
            var dataModel = Models.SingleOrDefault(x => x.ListElement.KeyToString() == Payload.ListElement.KeyToString());
            if (dataModel != null)
            {
                dataModel.State = newType;
                dataModel.ProductionCW = cw;
                await OnStateUpdate.InvokeAsync(Payload);

                OnOrderUpdate?.Invoke(this, dataModel);
            }
        }  
    }
}
