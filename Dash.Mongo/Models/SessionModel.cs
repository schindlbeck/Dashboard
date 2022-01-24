using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dash.Mongo.Models
{
    public class SessionModel
    {
        public string Location { get; set; } = string.Empty;

        public int Energy { get; set; } = 0;

        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        
        public TimeSpan TimeSpan { get; set; } = TimeSpan.Zero;

        public string Rfid { get; set; } = string.Empty;


    }
}
