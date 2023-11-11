namespace BuberDinner.Domain.MenuReview.ValueObject;

public sealed class MenuReviewId:Common.Models.ValueObject
{
    public Guid Value { get; }

    private MenuReviewId(Guid value)
    {
        Value = value;
    }

    public static MenuReviewId CreateUnique() => new(Guid.NewGuid());
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}