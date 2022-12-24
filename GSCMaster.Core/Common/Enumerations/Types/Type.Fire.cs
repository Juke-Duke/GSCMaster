using HotChocolate;

namespace GSCMaster.Core.Common.Enumerations.Types;
public abstract partial class Type
{
    private sealed class FireType : Type
    {
        public FireType() : base(nameof(Fire)) { }

        [GraphQLIgnore]
        public override Dictionary<Type, float> Effectiveness { get; } = new()
        {
            { Type.None,          1f },
            { Type.Normal,        1f },
            { Type.Fire,         .5f },
            { Type.Water,        .5f },
            { Type.Grass,         2f },
            { Type.Electric,      1f },
            { Type.Ice,           2f },
            { Type.Bug,           2f },
            { Type.Fighting,      1f },
            { Type.Flying,        1f },
            { Type.Poison,        1f },
            { Type.Rock,         .5f },
            { Type.Ground,        1f },
            { Type.Steel,         2f },
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
            { Type.Grass,        .5f },
            { Type.Electric,      1f },
            { Type.Ice,          .5f },
            { Type.Bug,          .5f },
            { Type.Fighting,      1f },
            { Type.Flying,        1f },
            { Type.Poison,        1f },
            { Type.Rock,          2f },
            { Type.Ground,        2f },
            { Type.Steel,        .5f },
            { Type.Dark,          1f },
            { Type.Psychic,       1f },
            { Type.Ghost,         1f },
            { Type.Dragon,        1f }
        };
    }
}