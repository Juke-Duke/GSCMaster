using HotChocolate;

namespace GSCMaster.Core.Common.Enumerations.Types;
public abstract partial class Type
{
    private sealed class GrassType : Type
    {
        public GrassType() : base(nameof(Grass)) { }

        [GraphQLIgnore]
        public override Dictionary<Type, float> Effectiveness { get; } = new()
        {
            { Type.None,          1f },
            { Type.Normal,        1f },
            { Type.Fire,         .5f },
            { Type.Water,         2f },
            { Type.Grass,        .5f },
            { Type.Electric,      1f },
            { Type.Ice,           1f },
            { Type.Bug,          .5f },
            { Type.Fighting,      1f },
            { Type.Flying,       .5f },
            { Type.Poison,       .5f },
            { Type.Rock,          2f },
            { Type.Ground,        2f },
            { Type.Steel,        .5f },
            { Type.Dark,          1f },
            { Type.Psychic,       1f },
            { Type.Ghost,         1f },
            { Type.Dragon,       .5f }
        };

        [GraphQLIgnore]
        public override Dictionary<Type, float> Resistances { get; } = new()
        {
            { Type.None,          1f },
            { Type.Normal,        1f },
            { Type.Fire,          2f },
            { Type.Water,        .5f },
            { Type.Grass,        .5f },
            { Type.Electric,     .5f },
            { Type.Ice,           2f },
            { Type.Bug,           2f },
            { Type.Fighting,      1f },
            { Type.Flying,        2f },
            { Type.Poison,        2f },
            { Type.Rock,          1f },
            { Type.Ground,       .5f },
            { Type.Steel,         1f },
            { Type.Dark,          1f },
            { Type.Psychic,       1f },
            { Type.Ghost,         1f },
            { Type.Dragon,        1f }
        };
    }
}