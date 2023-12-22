using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace IoTPlatform.Models.DTO
{
    /// <summary>
    /// Объект передачи данных для модели FabricObject
    /// </summary>
    public class FabricObjectDTO
    {
        /// <summary>
        /// Id родительского элемента (если есть)
        /// </summary>
        public string? ParentId { get; set; }

        /// <summary>
        /// Наименование объекта
        /// </summary>
        [JsonRequired]
        public string Name { get; set; }

        /// <summary>
        /// Тип или же уровень вложенности. Корневой элемент имеет тип = 0
        /// </summary>
        [JsonRequired]
        public int Type { get; set; }
    }
}