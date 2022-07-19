namespace Restaurant.Common.Infrastructure;


public interface IAppContext
{
    int? UserId { get; }
    string UserDisplayName { get; }
    bool IsAuthenticated { get; }
}