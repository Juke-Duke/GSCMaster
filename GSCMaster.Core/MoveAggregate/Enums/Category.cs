using HotChocolate;

namespace GSCMaster.Core.MoveAggregate.Enums;
public enum Category
{
    [GraphQLName("Physical")] Physical = 1,
    [GraphQLName("Special")] Special = 2,
    [GraphQLName("Status")] Status = 3
}