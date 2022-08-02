using Microsoft.AspNetCore.Components;
using GSCMaster.Core.DTOs;

namespace GSCMaster.Client.Components;
public partial class PokemonTokenComponent : ComponentBase
{
    [Parameter] public BasicPokemonDTO? Pokemon { get; set; }
}