using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using aspnet_identity_starter.ApiService.Models;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
  : IdentityDbContext<AppUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AppUser>(entity =>
        {
            entity.Property(e => e.EnableNotifications).HasDefaultValue(true);
            entity.Property(e => e.Initials).HasMaxLength(5);
        });

        builder.HasDefaultSchema("identity");
    }
}
