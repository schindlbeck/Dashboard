using Dash.Mongo.Models;
using EMobility.Models;
using Microsoft.AspNetCore.Components;

namespace Dash.Mongo.Pages
{
    public partial class FetchData : ComponentBase
    {
        private ChargingStationModel chargingSession;
        private SessionModel sessionModel;

        protected override async Task OnInitializedAsync()
        {
            sessionModel = new();
        }

        private void HandleValidSubmit()
        {
            chargingSession = new ChargingStationModel()
            {
                StationLocation = sessionModel.StationLocation,
                StationUrl = sessionModel.StationUrl,
                CpId = sessionModel.CpId
            };

            mongoService.AddChargingSession(chargingSession);
        }
    }
}
