using Microsoft.Extensions.Configuration;
using GSCMaster.Core.Common.Enums;
using GSCMaster.Core.Common.Primitives.Enums;
using GSCMaster.Core.ItemAggregate;
using GSCMaster.Core.MoveAggregate;
using GSCMaster.Core.MoveAggregate.Enums;
using GSCMaster.Core.PokemonAggregate;
using GSCMaster.Core.TeamAggregate;
using GSCMaster.Core.TeamMemberAggregate;
using GSCMaster.Core.TrainerAggregate;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace GSCMaster.Infrastructure;
public sealed class GSCMasterDBConnection
{
    public IMongoCollection<Pokemon> Pokemon { get; set; }

    public IMongoCollection<Move> Moves { get; set; }

    public IMongoCollection<Item> Items { get; set; }

    public IMongoCollection<Type> Types { get; set; }

    public IMongoCollection<Team> Teams { get; set; }

    public IMongoCollection<TeamMember> TeamMembers { get; set; }

    public IMongoCollection<Trainer> Trainers { get; set; }

    public GSCMasterDBConnection(IConfiguration config)
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
}