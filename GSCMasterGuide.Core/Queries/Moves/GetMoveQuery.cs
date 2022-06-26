using GSCMasterGuide.Core.DTOs;
using MediatR;

namespace GSCMasterGuide.Core.Queries.Moves;
public class GetMoveQuery : IRequest<FullMoveDTO?>
{
    public string Name { get; set; } = null!;

    public GetMoveQuery(string name)
        => Name = name;
}