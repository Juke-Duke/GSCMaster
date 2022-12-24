namespace GSCMaster.Core.Common.Primitives;
public abstract class Enumeration<TEnum> : IEquatable<Enumeration<TEnum>>
    where TEnum : Enumeration<TEnum>
{
    public string Identifier { get; init; }

    protected Enumeration(string identifier)
        => Identifier = identifier;

    public bool Equals(Enumeration<TEnum>? other)
        => other is Enumeration<TEnum>
        && Identifier == other.Identifier;

    public override bool Equals(object? obj)
        => Equals(obj as Enumeration<TEnum>);

    public override int GetHashCode()
        => Identifier.GetHashCode();

    public override string ToString()
        => Identifier;

    public static bool operator ==(Enumeration<TEnum>? left, Enumeration<TEnum>? right)
        => Equals(left, right);

    public static bool operator !=(Enumeration<TEnum>? left, Enumeration<TEnum>? right)
        => !Equals(left, right);
}