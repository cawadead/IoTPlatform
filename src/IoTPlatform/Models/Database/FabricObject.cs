using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace IoTPlatform.Models.Database
{
    /// <summary>
    /// ����� ������������ ������ �������� �� ������������
    /// </summary>
    public class FabricObject
    {
        /// <summary>
        /// Id �������
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Id ������������� �������� (���� ����)
        /// </summary>
        [BsonElement("parentId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ParentId { get; set; }

        /// <summary>
        /// ������������ �������
        /// </summary>
        [BsonElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// ��� ��� �� ������� �����������. �������� ������� ����� ��� = 0
        /// </summary>
        [BsonElement("type")]
        public int Type { get; set; }
    }
}