using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMobility.Models
{
    public class ChargingSession
    {
        //public int Id { get; set; }
        public string Location { get; set; } = string.Empty;
        public string TransactionWH { get; set; } = string.Empty;
        public DateTime TimeStamp { get; set; }
        public string? AuthId { get; set; }
        public string? Duration { get; set; }

    }
}
    