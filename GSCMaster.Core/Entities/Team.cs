using HotChocolate;
using MongoDB.Bson;

namespace GSCMaster.Core.Entities;
public sealed record Team
{
    [GraphQLIgnore]
    public ObjectId Id { get; init; }

    public required Trainer Trainer { get; set; }

    public required string TeamName { get; set; }

    public required TeamMember Lead { get; set; }

    public TeamMember? Member2 { get; set; }

    public TeamMember? Member3 { get; set; }

    public TeamMember? Member4 { get; set; }

    public TeamMember? Member5 { get; set; }

    public TeamMember? Member6 { get; set; }

    public required bool IsPublic { get; set; }
}