namespace GSCMasterGuide.Core.DTOs;
public class ItemDTO
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsConsumable { get; set; } = false;
}