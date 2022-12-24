using HotChocolate;

namespace GSCMaster.Core.Common.Enumerations.Types;
public abstract partial class Type
{
    private sealed class RockType : Type
    {
        public RockType() : base(nameof(Rock)) { }

        [GraphQLIgnore]
        public override Dictionary<Type, float> Effectiveness { get; } = new()
        {
            { Type.None,          1f },
            { Type.Normal,        1f },
            { Type.Fire,          2f },
            { Type.Water,         1f },
            { Type.Grass,         1f },
            { Type.Electric,      1f },
            { Type.Ice,           2f },
            { Type.Bug,           2f },
            { Type.Fighting,     .5f },
            { Type.Flying,        2f },
            { Type.Poison,        1f },
            { Type.Rock,          1f },
            { Type.Ground,       .5f },
            { Type.Steel,        .5f },
            { Type.Dark,          1f },
            { Type.Psychic,       1f },
            { Type.Ghost,         1f },
            { Type.Dragon,        1f }
        };

        public override Dictionary<Type, float> Resistances { get; } = new()
        {
            { Type.None,         .5f },
            { Type.Normal,        1f },
            { Type.Fire,         .5f },
            { Type.Water,         2f },
            { Type.Grass,         2f },
            { Type.Electric,      1f },
            { Type.Ice,           1f },
            { Type.Bug,           1f },
            { Type.Fighting,      2f },
            { Type.Flying,       .5f },
            { Type.Poison,       .5f },
            { Type.Rock,          1f },
            { Type.Ground,        2f },
            { Type.Steel,         2f },
            { Type.Dark,          1f },
            { Type.Psychic,       1f },
            { Type.Ghost,         1f },
            { Type.Dragon,        1f }
        };
    }
}