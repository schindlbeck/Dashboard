using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dash.Data
{
    public class PrioListElement
    {
        //TODO : no static implementation
        public const int WeeklyCapacity = 125000;


        public string Project { get; set; }

        public string OrderNr { get; set; }

        public DateTime DeliveryDate { get; set; }

        public int DeliveryCW { get; set; }

        public decimal Progress { get; set; }

        public int Position { get; set; }

        public int Quantity { get; set; }

        public int TimeTotal { get; set; }

        public int TimeOutstanding { get; set; }

        public int TimeDone { get; set; }

        public string KeyToString()
        {
            StringBuilder sb = new();
            sb.Append(Project).Append(": ")
                .Append(OrderNr);

            return sb.ToString();
        }


    }
}
