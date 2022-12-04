using HotChocolate;

namespace GSCMaster.Core.Enums;
public enum Gender
{
    [GraphQLName("Random")] Random,
    [GraphQLName("Genderless")] Genderless,
    [GraphQLName("Male")] Male,
    [GraphQLName("Female")] Female
}