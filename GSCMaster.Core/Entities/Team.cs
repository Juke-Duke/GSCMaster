using MongoDB.Bson;

namespace GSCMaster.Core.Entities;
public class Team
{
    [GraphQLIgnore]
    public ObjectId Id { get; init; }

    public Trainer Trainer { get; set; } = null!;

    public string TeamName { get; set; } = null!;

    public TeamMember Lead { get; set; } = null!;

    public TeamMember? Member2 { get; set; } = null;

    public TeamMember? Member3 { get; set; } = null;

    public TeamMember? Member4 { get; set; } = null;

    public TeamMember? Member5 { get; set; } = null;

    public TeamMember? Member6 { get; set; } = null;

    public bool IsPublic { get; set; }
}