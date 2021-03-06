using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSCMaster.Core.Entities;
public class Pokemon
{
    [Key] public int NationalNumber { get; init; }

    public string Name { get; set; } = null!;

    public Type PrimaryType { get; set; } = Type.None;

    public Type SecondaryType { get; set; } = Type.None;

    public Tier Tier { get; set; }

    public int HP { get; set; } = 0;

    public int Attack { get; set; } = 0;

    public int Defense { get; set; } = 0;

    public int SpAttack { get; set; } = 0;

    public int SpDefense { get; set; } = 0;

    public int Speed { get; set; } = 0;

    public Pokemon? PreEvolution { get; set; } = null;

    [InverseProperty("PreEvolution")]
    public ICollection<Pokemon> Evolution { get; set; } = new List<Pokemon>();

    public ICollection<Move> Moves { get; set; } = new List<Move>();
}