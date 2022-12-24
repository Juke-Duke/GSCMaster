using GSCMaster.Core.Common.Primitives;

namespace GSCMaster.Core.TeamMemberAggregate.ValueObjects;
public sealed class DV : ValueObject
{
    public const byte MinValue = 0;

    public const byte MaxValue = 15;

    public byte Value { get; }

    private DV(byte value)
        => Value = value;

    public static implicit operator DV(byte value)
        => new(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}