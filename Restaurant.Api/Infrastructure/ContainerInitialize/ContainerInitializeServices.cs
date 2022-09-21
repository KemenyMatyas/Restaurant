namespace Restaurant.Api.Infrastructure.ContainerInitialize;

using System.Text.Json.Serialization;
using Controllers.BaseControllers;
using Logic.BaseService;
using Logic.IServices;
using Logic.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Restaurant.Common.Infrastructure;
using Restaurant.Common.Mappers;

public static class  ContainerInitializeServices
{
    public static void Init(IServiceCollection services)
    {
        SetupManagers(services);
    }

    private static void SetupManagers(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapper));
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IAppContext, AppContext>();
        services.AddScoped<BaseService>();
        services.AddScoped<BaseController>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<AuthService>();
        services.AddScoped<IHomeService, HomeService>();
        services.AddControllers().AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
    }
}
