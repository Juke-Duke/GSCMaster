using HotChocolate;

namespace GSCMaster.Core.Common.Enumerations.Types;
public abstract partial class Type
{
    private sealed class WaterType : Type
    {
        public WaterType() : base(nameof(Water)) { }

        [GraphQLIgnore]
        public override Dictionary<Type, float> Effectiveness { get; } = new()
        {
            { Type.None,          1f },
            { Type.Normal,        1f },
            { Type.Fire,          2f },
            { Type.Water,        .5f },
            { Type.Grass,        .5f },
            { Type.Electric,      1f },
            { Type.Ice,           1f },
            { Type.Bug,           1f },
            { Type.Fighting,      1f },
            { Type.Flying,        1f },
            { Type.Poison,        1f },
            { Type.Rock,          2f },
            { Type.Ground,        2f },
            { Type.Steel,         1f },
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
            { Type.Fire,         .5f },
            { Type.Water,        .5f },
            { Type.Grass,         2f },
            { Type.Electric,      2f },
            { Type.Ice,          .5f },
            { Type.Bug,           1f },
            { Type.Fighting,      1f },
            { Type.Flying,        1f },
            { Type.Poison,        1f },
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