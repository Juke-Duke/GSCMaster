using GSCMaster.Core.Common.Enums;
using GSCMaster.Core.Common.Primitives;
using GSCMaster.Core.TeamMemberAggregate;
using GSCMaster.Core.TrainerAggregate;
using MongoDB.Bson;

namespace GSCMaster.Core.TeamAggregate;

public class Team : AggregateRoot
{
    public Trainer Trainer { get; }

    public string Name { get; }

    public Tier Format { get; }

    public bool IsPublic { get; }

    public TeamMember Lead => Members.First();

    public ICollection<TeamMember> Members { get; } = new List<TeamMember>();

    public Team(
        Trainer trainer,
        string name,
        bool isPublic,
        ICollection<TeamMember> members)
        : base(ObjectId.GenerateNewId())
    {
        Trainer = trainer;
        Name = name;
        IsPublic = isPublic;
        Members = members;
    }
}