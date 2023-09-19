using System.Security.Authentication;
using BoundlessBook.Common.Common.AspNetCore;
using BoundlessBook.Domain.RoleAggregate.Enums;
using BoundlessBook.Presentation.Facade.Roles;
using BoundlessBook.Presentation.Facade.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BoundlessBook.Bootstrapper.Infrastructure.Security;

public class PermissionChecker : AuthorizeAttribute , IAsyncAuthorizationFilter
{
    private IUserFacade _userFacade;
    private IRoleFacade _roleFacade;
    private readonly Permission _permission;

    public PermissionChecker(Permission permission)
    {
        _permission = permission;
    }
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        _userFacade = context.HttpContext.RequestServices.GetRequiredService<IUserFacade>();
        _roleFacade = context.HttpContext.RequestServices.GetRequiredService<IRoleFacade>();

        if (context.HttpContext.User.Identity.IsAuthenticated)
        {
            if (await UserHasPermission(context) == false)
            {
                context.Result = new ForbidResult();
            }
        }
        else
        {
            context.Result = new UnauthorizedObjectResult("UnAuthorize");
        }
    }

    public async Task<bool> UserHasPermission(AuthorizationFilterContext context)
    {
        var user = await _userFacade.GetUserById(context.HttpContext.User.GetUserId());
        if (user == null)
        {
            return false;
        }

        var rolIds = user.UserRoles.Select(c => c.RoleId).ToList();
        var roles = await _roleFacade.GetRoles();
        var userRoles = roles.Where(c => rolIds.Contains(c.Id));

        return userRoles.Any(c => c.RolePermissions.Contains(_permission));
    }
}