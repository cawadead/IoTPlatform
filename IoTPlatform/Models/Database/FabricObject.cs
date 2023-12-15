using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace IoTPlatform.Models.Database
{
    public class FabricObject
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("parentId")]
        public string ParentId { get; set; }

        [JsonIgnore]
        public FabricObject Parent { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("type")]
        public int ObjType { get; set; }
    }
}