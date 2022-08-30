namespace Restaurant.Api.Controllers.BaseControllers;

using Common.Infrastructure;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    private readonly IAppContext _appContext;
    
    public BaseController(IAppContext appContext)
    {
        _appContext = appContext;
    }
}