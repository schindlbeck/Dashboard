using EMobility.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Serilog;

namespace Dash.Mongo.Services
{
    public class MongoDbService
    {
        IMongoCollection<ChargingStationModel> _collection;
        public MongoDbService(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDbConnection");
            Log.Information("Connection: {cs}",connectionString );
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Supercharger");
            _collection = database.GetCollection<ChargingStationModel>("ChargingStations");
        }

        public void AddChargingSession(ChargingStationModel session)
        {
            _collection.InsertOne(session);
        }
    }
}