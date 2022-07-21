namespace Restaurant.Data.Models;

using Base;
using Enums;
using ManyToMany;

public class MenuItem : EntityBase
{
    public string Name { get; set; }
    public MenuCategory Category { get; set; }
    public MenuType Type { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    
    
    public IList<IngredientMenuItem> Ingredients { get; set; }
    public IList<OrderMenuItem> OrderMenuItems { get; set; }
}