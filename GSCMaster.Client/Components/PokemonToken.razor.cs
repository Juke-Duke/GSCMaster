using GSCMaster.Contracts.Responses;

namespace GSCMaster.Client.Components;
public partial class PokemonToken
{
    public IReadOnlyCollection<PokemonResponse> Pokemon { get; set; } = new List<PokemonResponse>();

    protected override async Task OnInitializedAsync()
    {
        var result = await Client.GetAllPokemon.ExecuteAsync();

        Names = result.Data!.AllPokemon.Select(x => x.Name).ToList();
    }
}