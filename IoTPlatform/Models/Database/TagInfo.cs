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

        //[BsonElement("type")]
        //public int Type { get; set; }
        //public string parentId { get; set; } //id оборудования по тегу
        //public string name { get; set; } //Русское название тега
        //public string description { get; set; }
        //public string tag { get; set; }
        //public string unit { get; set; }
        //public string status { get; set; }
        //[BsonElement("type")]
        //public int objType { get; set; }
    }
}