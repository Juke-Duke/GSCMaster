using GSCMaster.Core.Common.Primitives;

namespace GSCMaster.Core.TeamMemberAggregate.ValueObjects;
public sealed class EV : ValueObject
{
    public const byte MinValue = 0;

    public const byte MaxValue = 252;

    public byte Value { get; }

    private EV(byte value)
        => Value = value;

    public static implicit operator EV(byte value)
        => new(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}