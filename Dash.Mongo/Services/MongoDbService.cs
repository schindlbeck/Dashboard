using EMobility.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Dash.Mongo.Services
{
    public class MongoDbService
    {
        IMongoCollection<ChargingSession> _collection;
        //TODO : appsettings
        public MongoDbService(IConfiguration configuration)
        {
            var client = new MongoClient("mongodb+srv://lado:admin1910@emobility.dcut9.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            var database = client.GetDatabase("Supercharger");
            _collection = database.GetCollection<ChargingSession>("ChargingSessions");
        }

        public void AddChargingSession(ChargingSession session)
        {
            _collection.InsertOne(session);
        }
    }
}