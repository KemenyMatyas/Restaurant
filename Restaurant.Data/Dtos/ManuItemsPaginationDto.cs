namespace Restaurant.Data.Dtos;

public class ManuItemsPaginationDto
{
    public IList<MenuItemDto> Items { get; set; }
    public int Total {get; set;}
}