using MongoDB.Bson;
using MongoDB.Driver;

namespace IoTPlatform.Support
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string FabricObjectsCollectionName { get; set; } = null!;
        public string TimeSeriesCollectionName { get; set; } = null!;

        public static bool CollectionExists(IMongoDatabase database, string collectionName)
        {
            var filter = new BsonDocument("name", collectionName);
            var options = new ListCollectionNamesOptions { Filter = filter };

            return database.ListCollectionNames(options).Any();
        }
    }
}
