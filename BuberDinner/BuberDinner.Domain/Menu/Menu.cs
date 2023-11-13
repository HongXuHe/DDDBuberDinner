using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObject;
using BuberDinner.Domain.Host.ValueObject;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObject;
using BuberDinner.Domain.MenuReview.ValueObject;

namespace BuberDinner.Domain.Menu;

public sealed class Menu:AggregateRoot<MenuId>
{
    public Menu(MenuId id,string name, string description,
        HostId hostId,
        List<MenuSection> menuSections,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        _sections = menuSections;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    
    public string Name { get; }
    public string Description { get; }
    public float AverageRating { get; }
    public  IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public HostId HostId { get; set; }
    public  IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public  IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }

    public static Menu Create(string name, string description, HostId hostId,
        List<MenuSection> menuSections)
    {
        return new Menu(MenuId.CreateUnique(), name, description, hostId,menuSections,DateTime.UtcNow,DateTime.UtcNow);
    }
}