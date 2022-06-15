using GSCMasterGuide.Domain.DTOs;
using GSCMasterGuide.Domain.Entities;
using GSCMasterGuide.Domain.IRepositories;
using GSCMasterGuide.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GSCMasterGuide.Infrastructure.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly GSCDbContext _dbContext;

        public PokemonRepository(GSCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyCollection<BasicPokemonDTO>> GetAll()
            => await _dbContext.Pokemon.Select(p => DTOConverter
                .ConvertToBasic(p))
                .ToListAsync();
    }
}
