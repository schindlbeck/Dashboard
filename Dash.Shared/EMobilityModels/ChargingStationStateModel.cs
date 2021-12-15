using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMobility.Models
{
    public class ChargingStationStateModel
    {
        public List<ChargingSession> ChargingSessions { get; set; } = new();
        public ChargingSession ChargingSession { get; set; } = new();
        public CurrentChargingSessionInfo LastDbItem { get; set; } = new();
    }
}
