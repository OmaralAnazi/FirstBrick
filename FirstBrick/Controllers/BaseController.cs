using FirstBrick.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace FirstBrick.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    protected string UserId => User.Claims.FirstOrDefault(c => c.Type == "user_id")?.Value ?? throw ApiExceptions.Unauthorized;

}

