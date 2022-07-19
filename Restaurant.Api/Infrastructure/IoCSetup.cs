namespace Restaurant.Api.Infrastructure;

using ContainerInitialize;
using Restaurant.Common.Logging;

public static class IoCSetup
{
    public static void Init(IServiceCollection services, IConfiguration config,ILoggingBuilder logger)
    {
        ContainerInitializeServices.Init(services);

        ContainerInitializeDataBase.Init(services, config);
        
        ContainerInitializeAuth.Init(services, config);
        
        LogHelper.Init(config);
    }
}