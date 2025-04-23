using Domain.Entites.SecondaryDbEntities;
using MongoDB.Driver;

namespace Infrastructure.MongoDB.MongoDB;

public interface IDConnection
{
    IMongoCollection<TermsAndConditionEntity> TermsAndConditionsCollection { get; }
}
