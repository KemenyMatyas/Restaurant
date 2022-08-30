namespace Restaurant.Api.Controllers;

using BaseControllers;
using Common.Infrastructure;
using Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Logic.IServices;

public class UserController : BaseController
{
    private readonly IUserService _userService;

    public UserController(IAppContext appContext, IUserService userService) : base(appContext)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<ApiResponseDto<bool>> Register([FromBody]RegisterUserDto userDto)
    {

        var response = new ApiResponseDto<bool>();
        try
        {
            await _userService.Register(userDto);

            response.IsSuccess = true;
            response.Error = string.Empty;
            response.Data = true;

        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Error = ex.Message;
            response.Data = false;
        }
        
        return response;
    }
    
    [HttpPost("login")]
    public async Task<ApiResponseDto<string>> Login([FromBody]LoginUserDto userDto)
    {
        var response = new ApiResponseDto<string>();
        try
        {
            var res = await _userService.Login(userDto);
            if (res == null)
            {
                response.IsSuccess = false;
                response.Error = $"Nem sikerült a lekérni az elemeket";
                response.Data = null;
            }
            else
            {
                response.IsSuccess = true;
                response.Error = string.Empty;
                response.Data = res;
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Error = ex.Message;
            response.Data = null;
        }

        return response;
    }


}