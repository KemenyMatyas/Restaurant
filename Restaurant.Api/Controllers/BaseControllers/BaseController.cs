namespace Restaurant.Api.Controllers.BaseControllers;

using Common.Infrastructure;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    private readonly AppContext _appContext;
    
    protected BaseController(AppContext appContext)
    {
        _appContext = appContext;
    }
}