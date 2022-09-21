namespace Restaurant.Data.Dtos;

using Base;
using Enums;
using Models;
using Type = System.Type;

public class MenuItemDto : DtoBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public CategoryDto Category { get; set; }
    public List<IngredientDto> Ingredients { get; set; }
}