using GSCMaster.Core.Common.Primitives;
using GSCMaster.Core.TeamAggregate;
using MongoDB.Bson;

namespace GSCMaster.Core.TrainerAggregate;

public class Trainer : AggregateRoot
{
    public string Username { get; }

    public string Email { get; }

    public string Password { get; }

    public DateTime CreatedAt { get; }

    public ICollection<Team> Teams { get; } = new List<Team>();

    public Trainer(
        string username,
        string email,
        string password,
        DateTime createdAt)
        : base(ObjectId.GenerateNewId())
    {
        Username = username;
        Email = email;
        Password = password;
        CreatedAt = createdAt;
    }
}
