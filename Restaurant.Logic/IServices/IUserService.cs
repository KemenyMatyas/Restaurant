namespace Restaurant.Logic.IServices;

using FTBHungary.Data.Dtos;

public interface IUserService
{
    public Task Register(RegisterUserDto userDto);
    public Task<string> Login(LoginUserDto userDto);
}