namespace BuberDinner.Domain.Menu.ValueObject;

public sealed class MenuSectionId:Common.Models.ValueObject
{
    public Guid Value { get; }

    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public static MenuSectionId CreateUnique() => new(Guid.NewGuid());
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}