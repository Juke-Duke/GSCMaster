using GSCMasterGuide.Domain.DTOs;
using MediatR;

namespace GSCMasterGuide.API.Queries.Pokemon
{
    public class GetPokemonQuery : IRequest<FullPokemonDTO>
    {
        public string Name { get; set; } = null!;

        public GetPokemonQuery(string name)
            => Name = name;
    }
}