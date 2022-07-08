namespace GSCMaster.Core.Entities;
public class Item
{
    public int Id { get; init; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsConsumable { get; set; } = false;
}