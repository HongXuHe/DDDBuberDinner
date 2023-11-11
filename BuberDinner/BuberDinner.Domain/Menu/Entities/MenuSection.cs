using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObject;

namespace BuberDinner.Domain.Menu.Entities;

public sealed class MenuSection:Entity<MenuSectionId>
{
    public MenuSection(MenuSectionId id ,string name,string description) : base(id)
    {
        Name = name;
        Description = description;
    }

    private readonly List<MenuItem> _items = new ();
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();
    public string Name { get; }
    public string Description { get;}

    public static MenuSection Create(string name, string desc)
    {
        return new MenuSection(MenuSectionId.CreateUnique(), name, desc);
    }
}