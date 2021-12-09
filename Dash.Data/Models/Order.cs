using System;

namespace Dash.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Key { get; set; }

        public int ProductionCW { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int TimeTotal { get; set; }
    }
}
