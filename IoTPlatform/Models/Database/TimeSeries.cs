using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Linq;

namespace IoTPlatform.Models.Database
{
    public class TimeSeries
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("value")]
        public double Value { get; set; }

        [BsonElement("timestamp")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? Date { get; set; }
        /*
        public string parentId { get; set; } //id оборудования по тегу

        public string name { get; set; } //Русское название тега

        public string description { get; set; }

        public string tag { get; set; }

        public string unit { get; set; }

        public string status { get; set; }

        [BsonElement("type")]
        public int objType { get; set; }
        */
    }
}