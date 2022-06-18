using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TorSub.Domain.Common;

public class BaseEntity
{
    [BsonId]
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public DateTime Created { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string LastModifiedBy { get; set; }
}
