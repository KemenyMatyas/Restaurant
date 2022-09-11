namespace Restaurant.Data.Models;

using Base;
using ManyToMany;

public class Category : EntityBase
{
    public string Name { get; set; }
    
    public IList<CategoryMenu> MenuItem { get; set; }
}