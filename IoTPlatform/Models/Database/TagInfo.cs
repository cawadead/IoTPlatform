using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace IoTPlatform.Models.Database
{
    public class TagInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("parentId")]
        public string ParentId { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("type")]
        public int Type { get; set; }
    }
}