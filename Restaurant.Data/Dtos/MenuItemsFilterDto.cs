namespace Restaurant.Data.Dtos;

using Enums;

public class MenuItemsFilterDto
{


    public int PageNumber { get; set; } = 0;
    public int PageSize { get; set; } = 10;
    
    public string Name { get; set; } = "";
    public MenuCategory? Category { get; set; }
}