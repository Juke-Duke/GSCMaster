using GSCMaster.Core.Entities;
using GSCMaster.Core.Enums;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Type = GSCMaster.Core.Entities.Type;

namespace GSCMaster.Infrastructure.Database;
public class GSCMasterDBContext : IDisposable
{
    public IMongoCollection<Pokemon> Pokemon { get; set; }

    public IMongoCollection<Move> Moves { get; set; }

    public IMongoCollection<Item> Items { get; set; }

    public IMongoCollection<Type> Types { get; set; }

    public IMongoCollection<Team> Teams { get; set; }

    public IMongoCollection<TeamMember> TeamMembers { get; set; }

    public IMongoCollection<Trainer> Trainers { get; set; }

    public GSCMasterDBContext(IConfiguration config)
    {
        var client = new MongoClient(config.GetConnectionString("MongoDB"));
        var database = client.GetDatabase("GSCMasterDB");

        Pokemon = database.GetCollection<Pokemon>("Pokemon");
        Moves = database.GetCollection<Move>("Moves");
        Items = database.GetCollection<Item>("Items");
        Types = database.GetCollection<Type>("Types");
        Teams = database.GetCollection<Team>("Teams");
        TeamMembers = database.GetCollection<TeamMember>("TeamMembers");
        Trainers = database.GetCollection<Trainer>("Trainers");
        BsonSerializer.RegisterSerializer(new EnumSerializer<Gender>(BsonType.String));
        BsonSerializer.RegisterSerializer(new EnumSerializer<Category>(BsonType.String));
        BsonSerializer.RegisterSerializer(new EnumSerializer<Tier>(BsonType.String));
    }

    public void Dispose()
    {
        return;
    }
}