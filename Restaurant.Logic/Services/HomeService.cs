namespace Restaurant.Logic.Services;

using AutoMapper;
using BaseService;
using Data.Dtos;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using IServices;

public class HomeService : BaseService, IHomeService
{
    public HomeService(RestaurantContext dbContext, IMapper mapper, AuthService authService) : base(dbContext, mapper, authService)
    {
    }


    public async Task<IList<MenuItemDto>> GetMenuItemList()
    {
        var menuItems = await DbContext.MenuItems
            .Include(i => i.Ingredients)
            .ThenInclude(ti => ti.Ingredient)
            .ToListAsync();

        var menuItemsDto = menuItems.Select(menuItem => Mapper.Map<MenuItemDto>(menuItem)).ToList();
        
        return menuItemsDto;
    }

    public async Task<ManuItemsPaginationDto> GetMenuItemsPaginationFilter(MenuItemsFilterDto filter)
    {
        var menuItems = await DbContext.MenuItems
            .Include(i => i.Ingredients)
            .ThenInclude(ti => ti.Ingredient)
            .Where(i => i.Active && filter.Name == "" || i.Name.Contains(filter.Name))
            .Where(p => filter.Category == null || p.Category== filter.Category)
            .ToListAsync();
        
        
        
        var menuItemsPaged = menuItems
            .Skip(filter.PageNumber * filter.PageSize)
            .Take(filter.PageSize);

        var menuItemsDto = menuItemsPaged.Select(menuItem => Mapper.Map<MenuItemDto>(menuItem)).ToList();
        
        return new ManuItemsPaginationDto
        {
            Total = menuItems.Count,
            Items = menuItemsDto
        };
    }
}