using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMobility.Models
{
    public class ChargingStationInfoModel
    {
        public ChargingStationGeneralInfo ChargingStationGeneralInfo { get; set; } = new();
        public VehicleConnectionInfo VehicleConnectionInfo { get; set; } = new();
        public AuthentificationInfo AuthentificationInfo { get; set; } = new();
        public CurrentChargingSessionInfo ChargingSessionInfo { get; set; } = new();
    }
}
