using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace IoTPlatform.Models.DTO
{
    /// <summary>
    /// ������ �������� ������ ��� ������ FabricObject
    /// </summary>
    public class FabricObjectDTO
    {
        /// <summary>
        /// Id ������������� �������� (���� ����)
        /// </summary>
        public string? ParentId { get; set; }

        /// <summary>
        /// ������������ �������
        /// </summary>
        [JsonRequired]
        public string Name { get; set; }

        /// <summary>
        /// ��� ��� �� ������� �����������. �������� ������� ����� ��� = 0
        /// </summary>
        [JsonRequired]
        public int Type { get; set; }
    }
}