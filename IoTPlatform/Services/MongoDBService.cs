using IoTPlatform.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace IoTPlatform.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<FabricObject> fabricObjectsCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            fabricObjectsCollection = database.GetCollection<FabricObject>(mongoDBSettings.Value.FabricObjectsCollectionName);
        }

        public async Task<List<FabricObject>> GetFabricObjects()
        {
            return await fabricObjectsCollection.Find(new BsonDocument()).ToListAsync();
        }
    }
}
