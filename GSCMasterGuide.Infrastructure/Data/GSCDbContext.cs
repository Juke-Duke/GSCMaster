using Microsoft.EntityFrameworkCore;
using GSCMasterGuide.Domain.Entities;

namespace GSCMasterGuide.Infrastructure.Data
{
    public class GSCDbContext : DbContext
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

            builder.Entity<Pokemon>()
                .HasMany(p => p.Moves)
                .WithMany(m => m.EligiblePokemon)
                .UsingEntity<PokemonMove>();
        }
    }
}