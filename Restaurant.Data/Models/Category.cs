namespace Restaurant.Data.Models;

using Base;
using ManyToMany;

public class Category : EntityBase
{
    public string Name { get; set; }
    public IList<MenuItem> MenuItems { get; set; }

}