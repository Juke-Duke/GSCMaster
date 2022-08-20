// using Microsoft.AspNetCore.Identity;

using MongoDB.Bson;

namespace GSCMaster.Core.Entities;
public class Trainer
// : IdentityUser
{
    [GraphQLIgnore]
    public ObjectId Id { get; set; }
    // TODO remove - identityuser has passwordhash
    public string Password { get; set; } = null!;

    public DateTime CreatedAtDate { get; set; }

    public ICollection<Team> Teams { get; set; } = new List<Team>();
}