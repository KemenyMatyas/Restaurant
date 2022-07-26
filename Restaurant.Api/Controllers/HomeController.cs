﻿namespace Restaurant.Api.Controllers;

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
    
    [HttpGet("getMenuItemsPaginationFilter")]
    public async Task<ApiResponseListDto<MenuItemDto>> GetMenuItemsPaginationFilter([FromQuery] MenuItemsFilterDto filter)
    {

        var response = new ApiResponseListDto<MenuItemDto>();
        try
        {
            var items = await _homeService.GetMenuItemsPaginationFilter(filter);
            response.Data = items.Items.ToArray();
            response.IsSuccess = true;
            response.Error = string.Empty;
            response.Total = items.Total;
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Error = ex.Message;
            response.Total = 0;
        }
        
        return response;
    }
    
    [HttpGet("getCategories")]
    public async Task<ApiResponseListDto<CategoryDto>> GetCategories()
    {

        var response = new ApiResponseListDto<CategoryDto>();
        try
        {
            var items = await _homeService.GetCategories();
            response.Data = items.ToArray();
            response.IsSuccess = true;
            response.Error = string.Empty;
            response.Total = items.Count();
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Error = ex.Message;
            response.Total = 0;
        }
        
        return response;
    }
}