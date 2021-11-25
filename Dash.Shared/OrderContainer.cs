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
        public PrioListElement ListElement { get; init; }
        public int CurrentCW { get; set; }

        public OrderContainer(PrioListElement element) 
        { 
            ListElement = element;
            CurrentCW = element.CWPlanned;
        }

    }
}
