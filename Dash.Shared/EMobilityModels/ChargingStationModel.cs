using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMobility.Models
{
    
    public class ChargingStationModel
    {
#nullable disable
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
#nullable enable
        public string StationLocation { get; set; } = string.Empty;
        public string StationUrl { get; set; } = string.Empty;
        public string CpId { get; set; } = string.Empty;


    }
}
