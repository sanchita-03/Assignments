using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketBookingSystemApp.Identity.Configuration
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData
            (
                new IdentityRole
                {
                    Id = "88ab04a3-c435-4ee7-8c75-bbf66fc8f38d",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
               new IdentityRole
               {
                   Id = "88ab04a4-c435-4ee7-8c75-bbf66cd8f38e",
                   Name = "User",
                   NormalizedName = "USER"
               }
            );
        }
    }
}
