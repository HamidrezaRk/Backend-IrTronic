using Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entites.SecondaryDbEntities;
class TermsAndConditionEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public TermsAndConditionType Type { get; set; }
    public string? EnglishValue { get; set; }
    public string? ArabicValue { get; set; }
}