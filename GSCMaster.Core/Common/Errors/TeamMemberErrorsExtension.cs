using GSCMaster.Core.Common.Primitives;
using GSCMaster.Core.TeamMemberAggregate;

namespace GSCMaster.Core.Common.Errors;
public static class TeamMemberErrorsExtension
{
    public static Error InvalidNickname(this TeamMember teamMember)
        => new(code: $"{nameof(TeamMember)} - {nameof(InvalidNickname)}",
               message: $"{teamMember.Nickname} ({teamMember.Pokemon.Name}) can not have a nickname of another existing Pokemon.");

    public static Error EmptyMoveset(this TeamMember teamMember)
        => new(code: $"{nameof(TeamMember)} - {nameof(EmptyMoveset)}",
               message: $"{teamMember.Nickname} ({teamMember.Pokemon.Name}) has an empty moveset.");

    public static readonly Error IllegalMove = new(
        code: $"{nameof(TeamMember)} - {nameof(IllegalMove)}",
        message: "Has an illegal move.");

    public static readonly Error InvalidShiny = new(
        code: $"{nameof(TeamMember)} - {nameof(InvalidShiny)}",
        message: "");

    public static readonly Error SpecialDVMismatch = new(
        code: $"{nameof(TeamMember)} - {nameof(SpecialDVMismatch)}",
        message: "Team member has a mismatched special DV.");
}