using HotChocolate;

namespace GSCMaster.Core.Common.Enumerations.Types;
public abstract partial class Type
{
    private sealed class ElectricType : Type
    {
        public ElectricType() : base(nameof(Electric)) { }

        [GraphQLIgnore]
        public override Dictionary<Type, float> Effectiveness { get; } = new()
        {
            { Type.None,          1f },
            { Type.Normal,        1f },
            { Type.Fire,          1f },
            { Type.Water,         2f },
            { Type.Grass,        .5f },
            { Type.Electric,     .5f },
            { Type.Ice,           1f },
            { Type.Bug,           1f },
            { Type.Fighting,      1f },
            { Type.Flying,        2f },
            { Type.Poison,        1f },
            { Type.Rock,          1f },
            { Type.Ground,        0f },
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
            { Type.Fire,          1f },
            { Type.Water,         1f },
            { Type.Grass,         1f },
            { Type.Electric,     .5f },
            { Type.Ice,           1f },
            { Type.Bug,           1f },
            { Type.Fighting,      1f },
            { Type.Flying,       .5f },
            { Type.Poison,        1f },
            { Type.Rock,          1f },
            { Type.Ground,        2f },
            { Type.Steel,        .5f },
            { Type.Dark,          1f },
            { Type.Psychic,       1f },
            { Type.Ghost,         1f },
            { Type.Dragon,        1f }
        };
    }
}