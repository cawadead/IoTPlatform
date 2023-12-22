using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Linq;

namespace IoTPlatform.Models.Database
{
    /// <summary>
    /// Класс определяющий модель хранения временных рядов в БД
    /// </summary>
    public class TimeSeries
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("d")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? Date { get; set; }

        [BsonElement("v")]
        public double Value { get; set; }

        [BsonElement("metadata")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Metadata { get; set; }
    }
}