using Microsoft.AspNetCore.Components;

namespace GSCMaster.Client.Components;
public partial class StatComponent : ComponentBase
{
    [Parameter] public string? StatName { get; set; }
    [Parameter] public int StatValue { get; set; }
    private string? rgb;

    protected override void OnParametersSet()
    {
        rgb = $"rgb({GetRedValue()}, {GetGreenValue()}, {GetBlueValue()})";
    }

    private int GetRedValue()
    {
        if (StatValue >= 0 && StatValue <= 85)
            return 255;
        else if (StatValue >= 86 && StatValue <= 170)
            return 255 - (StatValue - 85) * 3;

        return 0;
    }

    private int GetGreenValue()
    {
        if (StatValue >= 0 && StatValue <= 85)
            return StatValue * 3;
        else if (StatValue >= 86 && StatValue <= 170)
            return 255;

        return 255;
    }

    private int GetBlueValue()
    {
        if (StatValue >= 0 && StatValue <= 85)
            return 0;
        else if (StatValue >= 86 && StatValue <= 170)
            return 0;

        return (StatValue - 170) * 3;
    }
}