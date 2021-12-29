using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dash.Mongo.Models
{
    public class SessionModel
    {
        public string StationLocation { get; set; } = string.Empty;

        public string StationUrl { get; set; } = string.Empty;

        public string CpId { get; set; } = string.Empty;

    }
}
