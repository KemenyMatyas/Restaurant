namespace Restaurant.Api.Controllers;

using BaseControllers;
using Common.Infrastructure;
using Data.Dtos;
using Logic.IServices;
using Microsoft.AspNetCore.Mvc;

public class HomeController : BaseController
{
    private readonly IHomeService _homeService;

    public HomeController(IAppContext appContext, IHomeService homeService) : base(appContext)
    {
        _homeService = homeService;
    }
    
    [HttpGet("getMenuItems")]
    public async Task<ApiResponseListDto<MenuItemDto>> GetMenuItems()
    {

        var response = new ApiResponseListDto<MenuItemDto>();
        try
        {
            var items = await _homeService.GetMenuItemList();
            response.Data = items.ToArray();
            response.IsSuccess = true;
            response.Error = string.Empty;
            response.Total = items.Count;
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Error = ex.Message;
        }
        
        return response;
    }
}