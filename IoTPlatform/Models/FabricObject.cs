using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace IoTPlatform.Models
{
    public class FabricObject
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }


        public string parentId { get; set; }

        public string name { get; set; }

        [BsonElement("type")]
        public int objType { get; set; }

        public FabricObject()
        {
            id = "";
            parentId = "";
            name = "";
        }
    }
}