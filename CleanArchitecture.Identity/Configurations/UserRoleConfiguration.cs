using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = "38abcc90-3ef9-4972-971b-a747242803f6",
                        UserId = "d33c60b4-5cbc-4cc7-947a-fdb4cf50d531"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "a07f7aa2-bed8-476c-96c2-17756001bcc0",
                        UserId = "1dc75d60-0e07-4f88-817e-6e46c2aee84e"
                    }
                );
        }
    }
}
