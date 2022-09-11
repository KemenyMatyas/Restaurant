namespace Restaurant.Data.Dtos;

using Enums;
using Models;

public class MenuItemsFilterDto
{


    public int PageNumber { get; set; } = 0;
    public int PageSize { get; set; } = 10;
    
    public string Name { get; set; } = "";
    public Guid CategoryID { get; set; }
}