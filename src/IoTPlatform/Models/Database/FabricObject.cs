using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace IoTPlatform.Models.Database
{
    /// <summary>
    /// Класс определяющий модель объектов на производстве
    /// </summary>
    public class FabricObject
    {
        /// <summary>
        /// Id объекта
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Id родительского элемента (если есть)
        /// </summary>
        [BsonElement("parentId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ParentId { get; set; }

        /// <summary>
        /// Наименование объекта
        /// </summary>
        [BsonElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Тип или же уровень вложенности. Корневой элемент имеет тип = 0
        /// </summary>
        [BsonElement("type")]
        public int Type { get; set; }
    }
}