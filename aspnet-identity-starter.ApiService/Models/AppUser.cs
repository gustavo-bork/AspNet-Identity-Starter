using Microsoft.AspNetCore.Identity;

namespace aspnet_identity_starter.ApiService.Models;

public sealed class AppUser : IdentityUser
{
    public bool EnableNotifications { get; set; }
    public string Initials { get; set; } = string.Empty;
}

