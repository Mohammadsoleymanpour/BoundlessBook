using BoundlessBook.Common.Common.AspNetCore;
using BoundlessBook.Presentation.Facade.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace BoundlessBook.Bootstrapper.Infrastructure.JwtUtils;

public class CustomJwtValidate
{
    private readonly IUserFacade _userFacade;

    public CustomJwtValidate(IUserFacade userFacade)
    {
        _userFacade = userFacade;
    }
    public async Task Validate(TokenValidatedContext context)
    {
        var userId = context.Principal.GetUserId();
        var jwtToken = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        var userToken = await _userFacade.GetUserTokenByToken(jwtToken);
        if (userToken == null)
        {
            context.Fail("Not Found Token");
            return;
        }

        var user = await _userFacade.GetUserById(userId);
        if (user == null || user.IsActive is false)
        {
            context.Fail("Cannot Find User");
        }
    }
}