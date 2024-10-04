using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using FirstBrick.Enums;

namespace FirstBrick.Attributes;

public class RequireAdminRoleAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (context.HttpContext.User.Identity == null)
            throw new ArgumentNullException(nameof(context));

        if (!context.HttpContext.User.Identity.IsAuthenticated)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var isAdmin = context.HttpContext.User.IsInRole(UserRolesEnum.ADMIN);
        if (!isAdmin)
            context.Result = new ForbidResult();
    }
}

