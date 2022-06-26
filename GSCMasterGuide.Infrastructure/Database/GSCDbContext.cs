using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GSCMasterGuide.Core.Entities;

namespace GSCMasterGuide.Infrastructure.Database;
public class GSCDbContext : IdentityDbContext<Trainer, IdentityRole<uint>, uint>
{
    public GSCDbContext(DbContextOptions<GSCDbContext> options) : base(options) {}

    public DbSet<Pokemon> Pokemon => Set<Pokemon>();

    public DbSet<Move> Moves => Set<Move>();

    public DbSet<Item> Items => Set<Item>();

    public DbSet<PokemonMove> PokemonMoves => Set<PokemonMove>();

    public DbSet<PokemonMember> PokemonMembers => Set<PokemonMember>();

    public DbSet<PokemonTeam> PokemonTeams => Set<PokemonTeam>();

    public DbSet<Trainer> Trainers => Set<Trainer>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Move>()
            .HasMany(m => m.EligiblePokemon)
            .WithMany(p => p.Moves)
            .UsingEntity<PokemonMove>();
    }
}