using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                    new ApplicationUser
                    {
                        Id = "d33c60b4-5cbc-4cc7-947a-fdb4cf50d531",
                        Email = "admin@localhost.com",
                        NormalizedEmail = "admin@localhost.com",
                        Firstname = "Jose",
                        Lastname = "Martinez",
                        UserName = "josem",
                        NormalizedUserName = "josem",
                        PasswordHash = hasher.HashPassword(null, "Cata1472.,"),
                        EmailConfirmed = true,
                    },
                    new ApplicationUser
                    {
                        Id = "1dc75d60-0e07-4f88-817e-6e46c2aee84e",
                        Email = "juanperez@localhost.com",
                        NormalizedEmail = "juanperez@localhost.com",
                        Firstname = "Juan",
                        Lastname = "Perez",
                        UserName = "juanperez",
                        NormalizedUserName = "juanperez",
                        PasswordHash = hasher.HashPassword(null, "Cata1472.,"),
                        EmailConfirmed = true,
                    }
                );
        }
    }
}
