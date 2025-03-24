﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentManagementSystem.Configurations
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
                    Id = "88ab04a4-c435-4ee7-8c75-bbf66cd8f38d",
                    Name = "Student",
                    NormalizedName = "STUDENT"
               },
               new IdentityRole
               {
                    Id = "88ab04a5-c435-4ee7-8c75-bbf66cd8f38d",
                    Name = "Teacher",
                    NormalizedName = "TEACHER"
               }
            );
        }
    }
}
