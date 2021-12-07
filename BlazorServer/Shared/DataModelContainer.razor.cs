using BlazorServer.Models;
using Dash.Data;
using Dash.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Shared
{
    public partial class DataModelContainer
    {
        public List<OrderContainer> Models { get; set; }
        public RenderFragment ChildContent { get; set; }
        public EventCallback<OrderContainer> OnStateUpdate { get; set; }
        public OrderContainer Payload { get; set; }

        public async Task UpdateOrderAsync(TaskState newType, int cw)
        {
            var dataModel = Models.SingleOrDefault(x => x.ListElement.KeyToString() == Payload.ListElement.KeyToString());
            if (dataModel != null)
            {
                //dataModel.State = newType;
                dataModel.ProductionCW = cw;
                await OnStateUpdate.InvokeAsync(Payload);
            }
        }
    }
}
