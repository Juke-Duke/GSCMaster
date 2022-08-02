using Microsoft.AspNetCore.Components;
using GSCMaster.Core.DTOs;

namespace GSCMaster.Client.Components;
public partial class BaseStatsComponent : ComponentBase
{
    [Parameter] public FullPokemonDTO? Pokemon { get; set; }
}