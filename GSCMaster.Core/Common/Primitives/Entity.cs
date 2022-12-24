using MongoDB.Bson;

namespace GSCMaster.Core.Common.Primitives;
public abstract class Entity : IEquatable<Entity>
{
    public ObjectId Id { get; init; }

    protected Entity(ObjectId id)
        => Id = id;

    public bool Equals(Entity? other)
        => other is Entity
        && Id == other.Id;

    public override bool Equals(object? obj)
        => Equals(obj as Entity);

    public override int GetHashCode()
        => Id.GetHashCode();

    public static bool operator ==(Entity? left, Entity? right)
        => Equals(left, right);

    public static bool operator !=(Entity? left, Entity? right)
        => !Equals(left, right);
}