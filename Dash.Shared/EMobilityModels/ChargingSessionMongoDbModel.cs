using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;

namespace EMobility.Data
{
#nullable enable
    public class ChargingSessionMongoDbModel
    {
#nullable disable
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
#nullable enable

        public string Location { get; set; } = string.Empty;

        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdate { get; set; } = DateTime.UtcNow;

        public int SessionId { get; init; } = 5;
        public int ConnectionId { get; init; } = 5;


        public DateTime StartDate { get; init; } = DateTime.UtcNow;

        public TimeSpan LocalStartTime { get; init; } = DateTime.Now.TimeOfDay;  // local time

        public TimeSpan DurationOf { get; init; }

        public int Energy { get; init; }

        public string? RfidTag { get; init; }

        public string? ChargingStation { get; init; }
    }

}