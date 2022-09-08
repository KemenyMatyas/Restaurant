namespace Restaurant.Logic.IServices;

using Data.Dtos;

public interface IHomeService
{
    public Task<IList<MenuItemDto>> GetMenuItemList();
}