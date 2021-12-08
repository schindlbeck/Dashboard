using Dash.Data;
using System;

namespace Dash.Shared
{
    public class OrderContainer
    {
        public delegate void OrderContainerEventHandler(object sender, EventArgs e);

        public event OrderContainerEventHandler OrderProductionCWChanged;
        public PrioListElement ListElement { get; init; }
        public int ProductionCW { get; set; }
        public int CurrentYear { get; set; }

        public TaskState State { get; set; }

        public OrderContainer(PrioListElement element)
        {
            ListElement = element;
            ProductionCW = element.DeliveryCW;
            CurrentYear = element.DeliveryDate.Year;
        }

        public void ProductionCWChanged()
        {
            OrderProductionCWChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public enum TaskState { Scheduled, New, InProgress, Finished };

}
