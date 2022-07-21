namespace Restaurant.Data.Models.ManyToMany;

using Base;

public class IngredientMenuItem : EntityBase
{
    public Guid IngredientId { get; set; }
    public Ingredient Ingredient { get; set; }
    public Guid MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; }
}