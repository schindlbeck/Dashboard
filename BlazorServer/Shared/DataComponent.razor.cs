using Dash.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Shared
{
    public partial class DataComponent
    {
        [CascadingParameter] DataModelContainer DataContainer { get; set; }
        [Parameter] public OrderContainer DataModel { get; set; }

        private string draggable = "draggable";

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
