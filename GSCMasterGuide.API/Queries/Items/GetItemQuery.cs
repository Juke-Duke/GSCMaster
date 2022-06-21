using GSCMasterGuide.Domain.DTOs;
using MediatR;

namespace GSCMasterGuide.Infrastructure.Queries.Items
{
    public class GetItemQuery : IRequest<ItemDTO?>
    {
        public string Name { get; set; }

        public GetItemQuery(string name)
            => Name = name;
    }
}
