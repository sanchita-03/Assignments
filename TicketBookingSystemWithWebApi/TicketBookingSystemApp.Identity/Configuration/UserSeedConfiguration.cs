using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketBookingSystemApp.Identity.Model;

namespace TicketBookingSystemApp.Identity.Configuration
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData
            (
                new ApplicationUser
                {
                    Id = "41776062-6086-1fbf-b923-2879a6680b9a",
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Admin@123"),
                    FirstName = "Admin",
                    LastName = "System"
                },
                new ApplicationUser
                {
                    Id = "41776062-6086-1fbf-b923-2879a6680b9b",
                    UserName = "mandhare@gmail.com",
                    NormalizedUserName = "MANDHARE@GMAIL.COM",
                    Email = "mandhare@gmail.com",
                    NormalizedEmail = "MANDHARE@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Sanchita@123"),
                    FirstName = "Sanchita",
                    LastName = "Mandhare"
                }
            );
        }
    }
}
