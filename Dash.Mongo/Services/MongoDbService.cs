using EMobility.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Serilog;

namespace Dash.Mongo.Services
{
    public class MongoDbService
    {
        IMongoCollection<ChargingSession> _collection;
        //TODO : appsettings
        public MongoDbService(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDbConnection");
            Log.Information("Connection: {cs}",connectionString );
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Supercharger");
            _collection = database.GetCollection<ChargingSession>("ChargingSessions");
        }

        public void AddChargingSession(ChargingSession session)
        {
            _collection.InsertOne(session);
        }
    }
}