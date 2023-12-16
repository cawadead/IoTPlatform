using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace IoTPlatform.Models.DTO
{
    public class FabricObjectDTO
    {
        public string? ParentId { get; set; }

        [JsonRequired]
        public string Name { get; set; }

        [JsonRequired]
        public int Type { get; set; }
    }
}