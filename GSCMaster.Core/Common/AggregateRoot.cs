using MongoDB.Bson;

namespace GSCMaster.Core.Common;
public abstract class AggregateRoot : Entity
{
    protected AggregateRoot(ObjectId id)
        : base(id) { }
}