using Dash.Mongo.Models;
using EMobility.Data;
using EMobility.Models;
using Microsoft.AspNetCore.Components;

namespace Dash.Mongo.Pages
{
    public partial class FetchData : ComponentBase
    {
        private ChargingSessionMongoDbModel chargingSession;
        private SessionModel sessionModel;

        protected override async Task OnInitializedAsync()
        {
            sessionModel = new();
        }

        private void HandleValidSubmit()
        {
            chargingSession = new ChargingSessionMongoDbModel()
            {
                Location = sessionModel.Location,
                RfidTag = sessionModel.Rfid,
                Energy = sessionModel.Energy,
                DurationOf = (new DateTime(2022, 01, 5, 4, 30, 0)).TimeOfDay,
                StartDate = sessionModel.DateTime
            };

            mongoService.AddChargingSession(chargingSession);
        }
    }
}
