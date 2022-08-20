using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GSCMaster.Core.Enums;

public enum Category
{
    [GraphQLName("Physical")] Physical = 1,
    [GraphQLName("Special")] Special = 2,
    [GraphQLName("Status")] Status = 3
}