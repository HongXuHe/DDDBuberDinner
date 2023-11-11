using BuberDinner.Domain.Common.Models;
namespace BuberDinner.Domain.Menu.ValueObject;

public sealed class MenuId:Common.Models.ValueObject
{
    public Guid Value { get; }

    private MenuId(Guid value)
    {
        Value = value;
    }

    public static MenuId CreateUnique() => new(Guid.NewGuid());
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}