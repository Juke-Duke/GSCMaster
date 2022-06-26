using GSCMasterGuide.Core.DTOs;
using MediatR;

namespace GSCMasterGuide.Core.Queries.Items;
public class GetItemQuery : IRequest<ItemDTO?>
{
    public string Name { get; set; }

    public GetItemQuery(string name)
        => Name = name;
}