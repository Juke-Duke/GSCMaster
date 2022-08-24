using System.Collections.Generic;
using GSCMaster.Core.Entities;
using HotChocolate;

namespace GSCMaster.Application.IRepositories;
public interface IPokemonRepository
{
    Task<IReadOnlyCollection<Pokemon>> GetAllPokemonAsync();

    Task<Pokemon?> GetPokemonByNameAsync(string name);
}