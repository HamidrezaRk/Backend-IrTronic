using Domain.Entites.SecondaryDbEntities;
using Infrastructure.MongoDB.Configuration;
using MongoDB.Driver;
using System.Security.Cryptography;

namespace Infrastructure.MongoDB.MongoDB;

public class DbConnection : IDConnection
{
    private readonly IMongoDatabase _db;
    private string TermsAndConditionsCollectionName { get; } = "TermsAndConditions";

    public IMongoClient Client { get; init; }

    public IMongoCollection<TermsAndConditionEntity> TermsAndConditionsCollection { get; private set; }


    public DbConnection(IMongoClient mongoClient, MongoDBSettings mongoDBSettings)
    {
        Client = mongoClient;
        _db = Client.GetDatabase(mongoDBSettings.DatabaseName);
        TermsAndConditionsCollection = _db.GetCollection<TermsAndConditionEntity>(TermsAndConditionsCollectionName);
    }
}
