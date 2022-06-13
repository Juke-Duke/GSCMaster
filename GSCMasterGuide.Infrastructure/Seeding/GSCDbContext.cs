using Microsoft.EntityFrameworkCore;
using GSCMasterGuide.Domain.Entities;

namespace GSCAPI.Data
{
    public class GSCDbContext : DbContext
    {
        public GSCDbContext(DbContextOptions<GSCDbContext> options) : base(options) {}

        public DbSet<Pokemon> Pokemon => Set<Pokemon>();

        public DbSet<Move> Moves => Set<Move>();

        public DbSet<Item> Items => Set<Item>();

        public DbSet<PokemonMove> PokemonMoves => Set<PokemonMove>();

        public DbSet<PokemonMember> PokemonMembers => Set<PokemonMember>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pokemon>()
                .HasMany(p => p.Moves)
                .WithMany(m => m.EligiblePokemon)
                .UsingEntity<PokemonMove>();
        }
    }
}