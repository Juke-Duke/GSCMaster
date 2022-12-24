using GSCMaster.Core.Common.Primitives;
using GSCMaster.Core.TeamAggregate;

namespace GSCMaster.Core.Common.Errors;
public static class TeamErrors
{
    public static readonly Error EmptyTeam = new(
        code: $"{nameof(Team)} - {nameof(EmptyTeam)}",
        message: "Team must have at least one team member.");
}