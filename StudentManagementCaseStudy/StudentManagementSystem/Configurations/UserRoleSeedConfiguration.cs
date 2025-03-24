using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementSystem.Configurations
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "4588227f-ec2c-4077-aeca-a7ca8df30b4b", 
                    RoleId = "88ab04a3-c435-4ee7-8c75-bbf66fc8f38d"
                }
            );
        }
    }
}
