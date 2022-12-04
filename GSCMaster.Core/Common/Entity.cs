using MongoDB.Bson;

namespace GSCMaster.Core.Common;
public abstract class Entity : IEquatable<Entity>
{
    public ObjectId Id { get; init; }

    protected Entity(ObjectId id)
        => Id = id;

    public bool Equals(Entity? other)
        => Equals((object?)other);

    public override bool Equals(object? obj)
        => obj is Entity entity
        && Id.Equals(entity.Id);

    public override int GetHashCode()
        => Id.GetHashCode();

    public static bool operator ==(Entity? left, Entity? right)
        => Equals(left, right);

    public static bool operator !=(Entity? left, Entity? right)
        => !Equals(left, right);
}