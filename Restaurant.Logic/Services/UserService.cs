namespace Restaurant.Logic.Services;

using AutoMapper;
using BaseService;
using Common.Exceptions;
using Common.Logging;
using Data.Dtos;
using Data.Enums;
using Data.Models;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using IServices;
using static BCrypt.Net.BCrypt;
public class UserService : BaseService, IUserService
{

    public UserService(RestaurantContext dbContext, IMapper mapper, AuthService authService) : base(dbContext, mapper, authService)
    {
    }
    public async Task Register(RegisterUserDto registerUserDtoDto)
    {
        try
        {
            registerUserDtoDto.Password = HashPassword(registerUserDtoDto.Password);
            var user = Mapper.Map<User>(registerUserDtoDto);
            
            // set role as user
            user.UserRole = Role.User;
            
            var userNameCheck = await DbContext.Users
                .Where(x => x.Email == user.Email).SingleOrDefaultAsync();
            if (userNameCheck != null)
            {
                throw new Exception("Felhasználónév foglalt");
            }

            await DbContext.Users.AddAsync(user);
            await DbContext.SaveChangesAsync();
            LogHelper.Security.ForContext<UserService>().Warning($"A felhasználó regisztrált a rendszerbe.({user.Guid}:{user.Email})");
            LogHelper.Activity.ForContext<UserService>().Information($"A felhasználó regisztrált a rendszerbe.({user.Guid}:{user.Email})");
        }
        catch (BusinessException ex)
        {
            if (!ex.IsLogged)
            {
                LogHelper.Diagnostic.ForContext<UserService>().Error(ex, "Regisztrációs hiba");

                ex.IsLogged = true;
            }

            throw;
        }
        catch (Exception ex)
        {
            LogHelper.Diagnostic.ForContext<UserService>().Error(ex, "Regisztrációs hiba");

            throw new BusinessException(ex.Message, ex) { IsLogged = true };
        }
    }

    public async Task<string> Login(LoginUserDto loginUserDto)
    {
        try
        {
            var user = await DbContext.Users
                .Where(w =>w.Email == loginUserDto.UserName).SingleOrDefaultAsync();
            if (user == null)
            {
                LogHelper.Security.ForContext<UserService>()
                    .Warning($"Nem létező felhasználónévvel próbáltak belépni.(Felhasználónév: {loginUserDto.UserName})");
                LogHelper.Diagnostic.ForContext<UserService>()
                    .Error($"Nem létező felhasználónévvel próbáltak belépni.(Felhasználónév: {loginUserDto.UserName})");
                throw new UnauthorizedAccessException("Hibás felhasználónév");
            }

            var valid = Verify(loginUserDto.Password, user.Password);
            if (!valid)
            {
                LogHelper.Security.ForContext<UserService>().Warning(
                    $"A felhasználó hibás jelszóval próbált belépni.(Felhasználó Id: {user.Guid} : Felhasználónév: {user.Email})");
                LogHelper.Diagnostic.ForContext<UserService>().Error(
                    $"A felhasználó hibás jelszóval próbált belépni.(Felhasználó Id: {user.Guid}:{user.Email})");
                throw new UnauthorizedAccessException("Hibás jelszó");
            }

            LogHelper.Security.ForContext<UserService>().Warning(
                $"A felhasználó bejelentkezett a rendszerbe.(Felhasználó Id: {user.Guid} : Felhasználónév: {user.Email})");
            LogHelper.Activity.ForContext<UserService>().Information(
                $"A felhasználó bejelentkezett a rendszerbe.(Felhasználó Id: {user.Guid} : Felhasználónév: {user.Email})");

            return AuthService.GetToken(user);
        }
        catch (BusinessException ex)
        {
            if (!ex.IsLogged)
            {
                LogHelper.Diagnostic.ForContext<UserService>().Error(ex, "Bejeletkezési hiba");

                ex.IsLogged = true;
            }

            throw;
        }
        catch (Exception ex)
        {
            LogHelper.Diagnostic.ForContext<UserService>().Error(ex, "Bejeletkezési hiba");

            throw new BusinessException(ex.Message, ex) {IsLogged = true};
        }
    }


}