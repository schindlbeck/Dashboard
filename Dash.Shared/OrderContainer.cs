using Dash.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dash.Shared
{
    public class OrderContainer
    {
        public delegate void OrderContainerEventHandler(object sender, EventArgs e);

        public event OrderContainerEventHandler OrderCwChanged;
        public PrioListElement ListElement { get; init; }
        public int CurrentCW { get; set; }
        public int CurrentYear { get; set; }

        public OrderContainer(PrioListElement element)
        {
            ListElement = element;
            CurrentCW = element.CWPlanned;
            CurrentYear = element.DeliveryDate.Year;
        }

        public void CurrentCwChanged()
        {
            OrderCwChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
