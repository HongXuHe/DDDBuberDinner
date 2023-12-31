﻿using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObject;

namespace BuberDinner.Domain.Menu.Entities;

public sealed class MenuItem:Entity<MenuItemId>
{
    public MenuItem(MenuItemId id ,string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }
    
    public string Name { get; }
    public string Description { get;}

    public static MenuItem Create(string name, string description)
    {
        return new MenuItem(MenuItemId.CreateUnique(), name, description);
    }
}