namespace Restaurant.Data.Dtos;

using Base;
using Enums;

public class MenuItemDto : DtoBase
{
    public string Name { get; set; }
    public MenuCategory Category { get; set; }
    public MenuType Type { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public List<IngredientDto> Ingredients { get; set; }
}