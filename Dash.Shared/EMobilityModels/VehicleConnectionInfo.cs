using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMobility.Models
{
#nullable enable
    //[Table("VehicleConnectionStates")]
    public class VehicleConnectionInfo
    {
        public string Location { get; set; } = string.Empty;
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string ConnState { get; set; } = string.Empty;
        public string ConnStateTrans { get; set; } = string.Empty;

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append(Location).Append('/')
            .Append(TimeStamp).Append('/')
            .Append(ConnState).Append('/')
            .Append(ConnStateTrans);

            return sb.ToString();
        }
    }
}
