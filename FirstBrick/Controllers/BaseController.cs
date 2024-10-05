using FirstBrick.Enums;
using FirstBrick.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace FirstBrick.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    protected string UserId => User.Claims.FirstOrDefault(c => c.Type == UserClaimsType.USER_ID)?.Value ?? throw ApiExceptions.Unauthorized;

}

