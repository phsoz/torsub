using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TorSub.Domain.Common;

namespace TorSub.Domain.Entities;

public class Tests : BaseEntity
{

    [BsonElement("Name")]
    public string BookName { get; set; } = null!;

    public decimal Price { get; set; }

    public string Category { get; set; } = null!;

    public string Author { get; set; } = null!;
}
