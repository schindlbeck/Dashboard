using Dash.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Shared
{
    public partial class DataComponent
    {
        [CascadingParameter] DataModelContainer DataContainer { get; set; }
        [Parameter] public OrderContainer DataModel { get; set; }

        private string draggable = "draggable";

        public DataComponent()
        {
            DataContainer.OnOrderUpdate += DataContainer_OnOrderUpdate;
        }

        private void DataContainer_OnOrderUpdate(object? sender, OrderContainer e)
        {
            if (e.ProductionCW < e.ListElement.DeliveryCW)
            {
                draggable = "draggableok";
            }
            else if (e.ProductionCW > e.ListElement.DeliveryCW)
            {
                draggable = "draggablelate";
            }
        }

        private void HandleDragStart(OrderContainer orderContainer)
        {
            DataContainer.Payload = orderContainer;
        }

        private void HandleDragDrop(OrderContainer orderContainer)
        {
            if(orderContainer.ProductionCW < orderContainer.ListElement.DeliveryCW)
            {
                draggable = "draggableok";
            }
            else if(orderContainer.ProductionCW > orderContainer.ListElement.DeliveryCW)
            {
                draggable = "draggablelate";
            }
        }
    }
}
