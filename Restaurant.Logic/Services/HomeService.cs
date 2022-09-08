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
    
}