using System.Security.Claims;

namespace BoundlessBook.Common.Common.AspNetCore;

public static class ClaimUtils
{
    public static Guid GetUserId(this ClaimsPrincipal principal)
    {
        if (principal == null)
            throw new ArgumentNullException(nameof(principal));
        return Guid.Parse((ReadOnlySpan<char>)principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);

    }
    public static string GetPhoneNumber(this ClaimsPrincipal principal)
    {
        if (principal == null)
            throw new ArgumentNullException(nameof(principal));

        return principal.FindFirst(ClaimTypes.MobilePhone)?.Value;
    }
}