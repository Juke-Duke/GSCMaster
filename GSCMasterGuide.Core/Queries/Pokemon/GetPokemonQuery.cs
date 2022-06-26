using GSCMasterGuide.Core.DTOs;
using MediatR;

namespace GSCMasterGuide.Core.Queries.Pokemon;
public class GetPokemonQuery : IRequest<FullPokemonDTO?>
{
    public string Name { get; set; } = null!;

    public GetPokemonQuery(string name)
        => Name = name;
}