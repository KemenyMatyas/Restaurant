namespace Restaurant.Logic.Services;

using AutoMapper;
using Common.Exceptions;
using Common.Logging;
using Data.Models;
using DataAccess;
using FTBHungary.Data.Dtos;
using Microsoft.EntityFrameworkCore;
using IServices;
using static BCrypt.Net.BCrypt;
public class UserService : IUserService
{
    private readonly RestaurantContext _dbContext;
    private readonly IMapper _mapper;
    private readonly AuthService _authService;

    public UserService(RestaurantContext dbContext, IMapper mapper, AuthService authService)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task Register(RegisterUserDto registerUserDtoDto)
    {
        try
        {
            registerUserDtoDto.Password = HashPassword(registerUserDtoDto.Password);
            var user = _mapper.Map<User>(registerUserDtoDto);
            user.UserRole = (await _dbContext.Roles.FindAsync(Guid.Parse("976c7e2b-9f46-4d0d-bdb8-7330358aabde")))!;
            var userNameCheck = await _dbContext.Users
                .Where(x => x.UserName == user.UserName).SingleOrDefaultAsync();
            if (userNameCheck != null)
            {
                throw new Exception("Felhasználónév foglalt");
            }

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            LogHelper.Security.ForContext<UserService>().Warning($"A felhasználó regisztrált a rendszerbe.({user.Guid}:{user.UserName})");
            LogHelper.Activity.ForContext<UserService>().Information($"A felhasználó regisztrált a rendszerbe.({user.Guid}:{user.UserName})");
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
            var user = await _dbContext.Users.Include(i => i.UserRole)
                .Where(w =>w.UserName == loginUserDto.UserName).SingleOrDefaultAsync();
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
                    $"A felhasználó hibás jelszóval próbált belépni.(Felhasználó Id: {user.Guid} : Felhasználónév: {user.UserName})");
                LogHelper.Diagnostic.ForContext<UserService>().Error(
                    $"A felhasználó hibás jelszóval próbált belépni.(Felhasználó Id: {user.Guid}:{user.UserName})");
                throw new UnauthorizedAccessException("Hibás jelszó");
            }

            LogHelper.Security.ForContext<UserService>().Warning(
                $"A felhasználó bejelentkezett a rendszerbe.(Felhasználó Id: {user.Guid} : Felhasználónév: {user.UserName})");
            LogHelper.Activity.ForContext<UserService>().Information(
                $"A felhasználó bejelentkezett a rendszerbe.(Felhasználó Id: {user.Guid} : Felhasználónév: {user.UserName})");

            return _authService.GetToken(user);
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