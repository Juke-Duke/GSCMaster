using HotChocolate;

namespace GSCMaster.Core.Common.Enumerations.Types;
public abstract partial class Type
{
    private sealed class FightingType : Type
    {
        public FightingType() : base(nameof(Fighting)) { }

        [GraphQLIgnore]
        public override Dictionary<Type, float> Effectiveness { get; } = new()
        {
            { Type.None,          1f },
            { Type.Normal,        2f },
            { Type.Fire,          1f },
            { Type.Water,         1f },
            { Type.Grass,         1f },
            { Type.Electric,      1f },
            { Type.Ice,           2f },
            { Type.Bug,          .5f },
            { Type.Fighting,      1f },
            { Type.Flying,       .5f },
            { Type.Poison,       .5f },
            { Type.Rock,          2f },
            { Type.Ground,        1f },
            { Type.Steel,         2f },
            { Type.Dark,          2f },
            { Type.Psychic,      .5f },
            { Type.Ghost,         0f },
            { Type.Dragon,        1f }
        };

        [GraphQLIgnore]
        public override Dictionary<Type, float> Resistances { get; } = new()
        {
            { Type.None,          1f },
            { Type.Normal,        1f },
            { Type.Fire,          1f },
            { Type.Water,         1f },
            { Type.Grass,         1f },
            { Type.Electric,      1f },
            { Type.Ice,           1f },
            { Type.Bug,          .5f },
            { Type.Fighting,      1f },
            { Type.Flying,        2f },
            { Type.Poison,        1f },
            { Type.Rock,         .5f },
            { Type.Ground,        1f },
            { Type.Steel,         1f },
            { Type.Dark,         .5f },
            { Type.Psychic,       2f },
            { Type.Ghost,         1f },
            { Type.Dragon,        1f }
        };
    }
}