// using GSCMaster.Core.Common.Errors;
// using GSCMaster.Core.TeamMemberAggregate;
// using HotChocolate.AspNetCore.Authorization;
// using MediatR;
// using Error = GSCMaster.Core.Common.Primitives.Error;

// namespace GSCMaster.API.GraphQL.Mutations;

// [MutationType]
// public static class TeamMemberMutations
// {
//     [Authorize]
//     public static MutationResult<TeamMember, Error> AddMember([Service] ISender mediator)
//     {
//         return TeamMemberErrors.EmptyMoveset;
//     }
// }