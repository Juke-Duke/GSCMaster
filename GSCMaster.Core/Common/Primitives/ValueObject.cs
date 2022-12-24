namespace GSCMaster.Core.Common.Primitives;
public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetEqualityComponents();

    public bool Equals(ValueObject? other)
        => other is not null
        && GetType() == other.GetType()
        && GetEqualityComponents()
            .SequenceEqual(other.GetEqualityComponents());

    public override bool Equals(object? obj)
        => Equals(obj as ValueObject);

    public override int GetHashCode()
        => GetEqualityComponents()
            .Select(component => component?.GetHashCode() ?? 0)
            .Aggregate((current, next) => current ^ next);

    public static bool operator ==(ValueObject? left, ValueObject? right)
        => Equals(left, right);

    public static bool operator !=(ValueObject? left, ValueObject? right)
        => !Equals(left, right);
}