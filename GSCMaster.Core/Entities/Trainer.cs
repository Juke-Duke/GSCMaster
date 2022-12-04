using HotChocolate;
using MongoDB.Bson;

namespace GSCMaster.Core.Entities;
public sealed record Trainer
{
    [GraphQLIgnore]
    public ObjectId Id { get; set; }

    public required string Username { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }

    public required DateTime CreatedAt { get; set; }

    public ICollection<Team> Teams { get; set; } = new List<Team>();
}