using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMobility.Models
{
    [Table("InfoChargingSessions")]
    public class CurrentChargingSessionInfo
    {
        public int Id { get; set; }
        public string Location { get; set; } = string.Empty;
        public DateTime TimeStamp { get; set; }
        public string? TimeSinceStart { get; set; }
        public string PowerW { get; set; } = string.Empty;
        public string? TransactionWH { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append(Location).Append('-')
            .Append(TimeStamp).Append('-')
            .Append(TimeSinceStart).Append('-')
            .Append(TransactionWH).Append('-')
            .Append(PowerW);

            return sb.ToString();
        }
    }
}
