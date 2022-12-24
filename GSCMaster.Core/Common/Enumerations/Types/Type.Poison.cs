using HotChocolate;

namespace GSCMaster.Core.Common.Enumerations.Types;
public abstract partial class Type
{
    private sealed class PoisonType : Type
    {
        public PoisonType() : base(nameof(Poison)) { }

        [GraphQLIgnore]
        public override Dictionary<Type, float> Effectiveness { get; } = new()
        {
            { Type.None,          1f },
            { Type.Normal,        1f },
            { Type.Fire,          1f },
            { Type.Water,         1f },
            { Type.Grass,         2f },
            { Type.Electric,      1f },
            { Type.Ice,           1f },
            { Type.Bug,           1f },
            { Type.Fighting,      1f },
            { Type.Flying,        1f },
            { Type.Poison,       .5f },
            { Type.Rock,         .5f },
            { Type.Ground,       .5f },
            { Type.Steel,         0f },
            { Type.Dark,          1f },
            { Type.Psychic,       1f },
            { Type.Ghost,        .5f },
            { Type.Dragon,        1f }
        };

        [GraphQLIgnore]
        public override Dictionary<Type, float> Resistances { get; } = new()
        {
            { Type.None,          1f },
            { Type.Normal,        1f },
            { Type.Fire,          1f },
            { Type.Water,         1f },
            { Type.Grass,        .5f },
            { Type.Electric,      1f },
            { Type.Ice,           1f },
            { Type.Bug,          .5f },
            { Type.Fighting,     .5f },
            { Type.Flying,        1f },
            { Type.Poison,       .5f },
            { Type.Rock,          1f },
            { Type.Ground,        2f },
            { Type.Steel,         1f },
            { Type.Dark,          1f },
            { Type.Psychic,       2f },
            { Type.Ghost,         1f },
            { Type.Dragon,        1f }
        };
    }
}