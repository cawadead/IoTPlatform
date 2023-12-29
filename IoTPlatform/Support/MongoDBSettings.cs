using MongoDB.Bson;
using MongoDB.Driver;

namespace IoTPlatform.Support
{
    public class MongoDBSettings
    {
        public string MONGODB_CONNECTION_STRING { get; set; } = null!;
        public string MONGODB_IOT_DATABASE_NAME { get; set; } = null!;
        public string FABRIC_OBJECT_COLLECTION { get; set; } = null!;
        public string TIME_SERIES_COLLECTION { get; set; } = null!;

        public static bool CollectionExists(IMongoDatabase database, string collectionName)
        {
            var filter = new BsonDocument("name", collectionName);
            var options = new ListCollectionNamesOptions { Filter = filter };

            return database.ListCollectionNames(options).Any();
        }
    }
}
