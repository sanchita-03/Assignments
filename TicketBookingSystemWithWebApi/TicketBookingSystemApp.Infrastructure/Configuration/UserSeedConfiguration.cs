using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketBookingSystemApp.Domain;

namespace TicketBookingSystemApp.Infrastructure.Configuration
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData
            (
                new User
                {
                    Id = 1,
                    UserName = "John Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "9876543210",
                },
                new User
                {
                    Id = 2,
                    UserName = "Jane Smith",
                    Email = "jane.smith@example.com",
                    PhoneNumber = "9876543211"
                }
            );
        }
    }
}
