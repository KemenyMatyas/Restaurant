namespace Restaurant.Logic.BaseService;

using AutoMapper;
using DataAccess;
using Services;

public class BaseService
{
    protected readonly RestaurantContext DbContext;
    protected IMapper Mapper;
    protected readonly AuthService AuthService;

    public BaseService(RestaurantContext dbContext, IMapper mapper, AuthService authService)
    {
        DbContext = dbContext;
        Mapper = mapper;
        AuthService = authService;
    }
    
    
}