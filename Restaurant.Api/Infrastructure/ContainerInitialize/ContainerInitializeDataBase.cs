namespace Restaurant.Api.Infrastructure.ContainerInitialize;

using DataAccess;
using Microsoft.EntityFrameworkCore;

public static class ContainerInitializeDataBase
{
    public static void Init(IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<RestaurantContext>(options =>
            options.UseNpgsql(config.GetConnectionString("RestaurantDB")));
    }
}


