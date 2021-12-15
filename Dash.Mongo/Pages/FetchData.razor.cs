using Dash.Mongo.Models;
using EMobility.Models;
using Microsoft.AspNetCore.Components;

namespace Dash.Mongo.Pages
{
    public partial class FetchData : ComponentBase
    {
        private ChargingSession chargingSession;
        private SessionModel sessionModel;

        protected override async Task OnInitializedAsync()
        {
            sessionModel = new();
        }

        private void HandleValidSubmit()
        {
            chargingSession = new ChargingSession()
            {
                Location = sessionModel.Location,
                TransactionWH = sessionModel.TransWH,
                TimeStamp = sessionModel.TimeStamp,
                AuthId = sessionModel.AuthId,
                Duration = sessionModel.Duration
            };

            mongoService.AddChargingSession(chargingSession);
        }
    }
}
