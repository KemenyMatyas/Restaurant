namespace Restaurant.Data.Models;

using Base;
using ManyToMany;

public class Ingredient : EntityBase
{
    public string Name { get; set; }
    
    public IList<IngredientMenuItem> MenuItems { get; set; }
}