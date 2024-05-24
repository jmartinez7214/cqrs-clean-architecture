using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                    new IdentityRole
                    {
                        Id = "38abcc90-3ef9-4972-971b-a747242803f6",
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR"
                    },
                    new IdentityRole
                    {
                        Id = "a07f7aa2-bed8-476c-96c2-17756001bcc0",
                        Name = "Operator",
                        NormalizedName = "OPERATOR"
                    }
                );
        }
    }
}
