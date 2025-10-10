using aspnet_identity_starter.ApiService.Models;
using Microsoft.AspNetCore.Identity;

namespace aspnet_identity_starter.ApiService.Endpoints;

public static class RegisterUserEndpoint
{
    public record Request(string Email, string Initials, string Password, bool EnableNotifications = false);

    public static void MapRegisterUserEndpoint(this WebApplication app)
    {
        app.MapPost("register", async (
              Request request,
              ApplicationDbContext dbContext,
              UserManager<AppUser> userManager) =>
        {
            using var transaction = await dbContext.Database.BeginTransactionAsync();

            var user = new AppUser
            {
                UserName = request.Email,
                Email = request.Email,
                Initials = request.Initials,
                EnableNotifications = request.EnableNotifications
            };

            var addUserResult = await userManager.CreateAsync(user, request.Password);

            if (!addUserResult.Succeeded)
            {
                return Results.BadRequest(addUserResult.Errors);
            }

            var addToRoleResult = await userManager.AddToRoleAsync(user, Roles.Member);

            if (!addToRoleResult.Succeeded)
            {
                return Results.BadRequest(addToRoleResult.Errors);
            }

            await transaction.CommitAsync();

            return Results.Ok(user);
        });
    }
}
