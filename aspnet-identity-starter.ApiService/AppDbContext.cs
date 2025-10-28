using aspnet_identity_starter.ApiService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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
      entity.ToTable("Users");
    });


    builder.Entity<IdentityUserClaim<string>>(entity =>
    {
      entity.ToTable("UserClaims");
    });

    builder.Entity<IdentityUserLogin<string>>(entity =>
    {
      entity.ToTable("UserLogins");
    });

    builder.Entity<IdentityUserToken<string>>(entity =>
    {
      entity.ToTable("UserTokens");
    });

    builder.Entity<IdentityUserRole<string>>(entity =>
    {
      entity.ToTable("UserRoles");
    });

    builder.Entity<IdentityUserToken<string>>(entity =>
    {
      entity.ToTable("UserTokens");
    });

    builder.Entity<IdentityRole>(entity =>
    {
      entity.ToTable("Roles");
    });

    builder.Entity<IdentityRoleClaim<string>>(entity =>
    {
      entity.ToTable("RoleClaims");
    });

    builder.HasDefaultSchema("identity");
  }
}
