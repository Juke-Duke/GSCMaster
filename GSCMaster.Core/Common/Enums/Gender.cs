using HotChocolate;

namespace GSCMaster.Core.Common.Primitives.Enums;
public enum Gender
{
    [GraphQLName("Random")] Random,
    [GraphQLName("Genderless")] Genderless,
    [GraphQLName("Male")] Male,
    [GraphQLName("Female")] Female
}