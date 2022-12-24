using GSCMaster.Core.Common.Primitives;
using GSCMaster.Core.MoveAggregate;
using GSCMaster.Core.PokemonAggregate;
using HotChocolate;
using HotChocolate.Types;

namespace GSCMaster.Core.Common.Enumerations.Types;
public abstract partial class Type : Enumeration<Type>
{
    public static readonly Type None = new NoneType();

    public static readonly Type Normal = new NormalType();

    public static readonly Type Fire = new FireType();

    public static readonly Type Water = new WaterType();

    public static readonly Type Grass = new GrassType();

    public static readonly Type Electric = new ElectricType();

    public static readonly Type Ice = new IceType();

    public static readonly Type Bug = new BugType();

    public static readonly Type Fighting = new FightingType();

    public static readonly Type Flying = new FlyingType();

    public static readonly Type Poison = new PoisonType();

    public static readonly Type Rock = new RockType();

    public static readonly Type Ground = new GroundType();

    public static readonly Type Steel = new SteelType();

    public static readonly Type Dark = new DarkType();

    public static readonly Type Psychic = new PsychicType();

    public static readonly Type Ghost = new GhostType();

    public static readonly Type Dragon = new DragonType();

    [GraphQLIgnore]
    public abstract Dictionary<Type, float> Effectiveness { get; }

    [GraphQLIgnore]
    public abstract Dictionary<Type, float> Resistances { get; }

    // public ICollection<Pokemon> Pokemon { get; } = new List<Pokemon>();

    // public ICollection<Move> Moves { get; } = new List<Move>();

    protected Type(string identifier)
        : base(identifier) { }

    public static bool TryParse(string identifier, out Type? enumeration)
    {
        identifier = identifier.ToLower();

        enumeration = identifier switch
        {
            "none" => None,
            "normal" => Normal,
            "fire" => Fire,
            "water" => Water,
            "grass" => Grass,
            "electric" => Electric,
            "ice" => Ice,
            "bug" => Bug,
            "fighting" => Fighting,
            "flying" => Flying,
            "poison" => Poison,
            "rock" => Rock,
            "ground" => Ground,
            "steel" => Steel,
            "dark" => Dark,
            "psychic" => Psychic,
            "ghost" => Ghost,
            "dragon" => Dragon,
            _ => null
        };

        return enumeration is not null;
    }
}