namespace BuberDinner.Domain.Host.ValueObject;

public sealed class HostId:Common.Models.ValueObject
{
    public string Value { get; }

    private HostId(string value)
    {
        Value = value;
    }

    public static HostId CreateUnique() => new(Guid.NewGuid().ToString());
    public static HostId Create(string value) => new HostId(value);
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}