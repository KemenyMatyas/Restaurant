namespace Restaurant.Data.Dtos;

using Enums;

public class MenuItemsFilterDto
{

    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public string Name { get; set; }
    public MenuCategory Category { get; set; }
}