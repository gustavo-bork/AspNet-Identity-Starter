using aspnet_identity_starter.ApiService.Models;
using Microsoft.AspNetCore.Identity;

namespace aspnet_identity_starter.ApiService.Endpoints;

public static class LoginUserEndpoint
{
    public record LoginRequest(string Email, string Password);

    public static WebApplication MapLoginUserEndpoint(this WebApplication app)
    {
        app.MapPost("login", async (
            LoginRequest request,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager) =>
        {
            var user = await userManager.FindByEmailAsync(request.Email);

            if (user is null)
            {
                return Results.BadRequest("Email or password are incorrect");
            }

            var signInResult = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!signInResult.Succeeded)
            {
                return Results.BadRequest("Incorrect email or password");
            }

            return Results.Ok();
        });

        return app;
    }
}
