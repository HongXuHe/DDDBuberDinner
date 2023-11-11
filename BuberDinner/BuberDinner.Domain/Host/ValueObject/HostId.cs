namespace BuberDinner.Domain.Host.ValueObject;

public sealed class HostId:Common.Models.ValueObject
{
    public Guid Value { get; }

    private HostId(Guid value)
    {
        Value = value;
    }

    public static HostId CreateUnique() => new(Guid.NewGuid());
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}