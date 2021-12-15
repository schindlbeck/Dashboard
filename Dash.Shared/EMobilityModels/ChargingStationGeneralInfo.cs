using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMobilityShared;

namespace EMobility.Models
{
    [Table("ChargingStationInfos")]
    public class ChargingStationGeneralInfo
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }

        [MaxLength(50)]
        public string CpId { get; set; } = string.Empty;
        public string MeterWh { get; set; } = string.Empty;
        public string? FreeCharging { get; set; } 
        public string? ConCyclesType2 { get; set; }
        public string? SlaveState { get; set; }
        public string? AmbientTemp { get; set; }
        public string? CpModel { get; set; }
        public string? CpVendor { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append(CpId).Append('-')
            .Append(MeterWh).Append('-')
            .Append(FreeCharging).Append('-')
            .Append(ConCyclesType2).Append('-')
            .Append(SlaveState).Append('-')
            .Append(AmbientTemp).Append('-')
            .Append(CpModel).Append('-')
            .Append(CpVendor).Append('-');
            return sb.ToString();
        }
    }
}
