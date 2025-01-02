using Microsoft.AspNetCore.Http;
using poc.trading.sdk.Authentication.Entity;
using System.IdentityModel.Tokens.Jwt;

public class TokenClaimsMiddleware
{
    private readonly RequestDelegate _next;

    public TokenClaimsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, UserContext userContext)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (!string.IsNullOrEmpty(token))
        {
            var handler = new JwtSecurityTokenHandler();
            if (handler.CanReadToken(token))
            {
                var jwtToken = handler.ReadJwtToken(token);

                // Extract claims
                var claims = jwtToken.Claims.ToDictionary(claim => claim.Type, claim => claim.Value);

                // Populate the service with claims
                userContext.Id = claims.TryGetValue("Id", out var Id) ? Id : null;
                userContext.UserName = claims.TryGetValue("UserName", out var UserName) ? UserName : null;
                userContext.Email = claims.TryGetValue("Email", out var email) ? email : null;
                userContext.Role = claims.TryGetValue("Role", out var role) ? role : null;
                userContext.FirstName = claims.TryGetValue("FirstName", out var FirstName) ? FirstName : null;
                userContext.LastName = claims.TryGetValue("LastName", out var LastName) ? LastName : null;
            }
        }

        await _next(context);
    }
}
