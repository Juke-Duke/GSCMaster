namespace GSCMaster.Core.Common;
public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetEqualityComponents();

    public bool Equals(ValueObject? other)
        => Equals((object?)other);

    public override bool Equals(object? obj)
        => obj is not null
        && obj.GetType() == GetType()
        && GetEqualityComponents()
            .SequenceEqual(((ValueObject)obj)
            .GetEqualityComponents());

    public override int GetHashCode()
        => GetEqualityComponents()
            .Select(component => component?.GetHashCode() ?? 0)
            .Aggregate((current, next) => current ^ next);

    public static bool operator ==(ValueObject? left, ValueObject? right)
        => Equals(left, right);

    public static bool operator !=(ValueObject? left, ValueObject? right)
        => !Equals(left, right);
}