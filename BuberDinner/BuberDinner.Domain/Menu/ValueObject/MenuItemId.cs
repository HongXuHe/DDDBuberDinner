namespace BuberDinner.Domain.Menu.ValueObject;

public sealed class MenuItemId:Common.Models.ValueObject
{
    public Guid Value { get; }

    private MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId CreateUnique() => new(Guid.NewGuid());
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}