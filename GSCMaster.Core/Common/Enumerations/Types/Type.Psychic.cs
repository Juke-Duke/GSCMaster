using HotChocolate;

namespace GSCMaster.Core.Common.Enumerations.Types;
public abstract partial class Type
{
    private sealed class PsychicType : Type
    {
        public PsychicType() : base(nameof(Psychic)) { }

        [GraphQLIgnore]
        public override Dictionary<Type, float> Effectiveness { get; } = new()
        {
            { Type.None,          1f },
            { Type.Normal,        1f },
            { Type.Fire,          1f },
            { Type.Water,         1f },
            { Type.Grass,         1f },
            { Type.Electric,      1f },
            { Type.Ice,           1f },
            { Type.Bug,           1f },
            { Type.Fighting,      2f },
            { Type.Flying,        1f },
            { Type.Poison,        2f },
            { Type.Rock,          1f },
            { Type.Ground,        1f },
            { Type.Steel,        .5f },
            { Type.Dark,          0f },
            { Type.Psychic,      .5f },
            { Type.Ghost,         1f },
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
            { Type.Bug,           2f },
            { Type.Fighting,     .5f },
            { Type.Flying,        1f },
            { Type.Poison,        1f },
            { Type.Rock,          1f },
            { Type.Ground,        1f },
            { Type.Steel,         1f },
            { Type.Dark,          2f },
            { Type.Psychic,      .5f },
            { Type.Ghost,         2f },
            { Type.Dragon,        1f }
        };
    }
}