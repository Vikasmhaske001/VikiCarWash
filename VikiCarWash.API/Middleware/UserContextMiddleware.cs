using System.Security.Claims;
using VikiCarWash.Domain.Enums;
using VikiCarWash.Infrastructure.Data;

namespace VikiCarWash.API.Middleware;

/// <summary>
/// Middleware to extract user identity from JWT claims and set it in the DbContext.
/// This ensures query filters automatically enforce data isolation.
/// </summary>
public class UserContextMiddleware
{
    private readonly RequestDelegate _next;

    public UserContextMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, AppDbContext dbContext)
    {
        var userIdClaim = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var roleClaim = context.User?.FindFirst(ClaimTypes.Role)?.Value;

        // Set user context if authenticated
        if (int.TryParse(userIdClaim, out var userId) && Enum.TryParse<UserRole>(roleClaim, out var role))
        {
            dbContext.SetCurrentUser(userId, role);
        }

        await _next(context);
    }
}
