using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Configurations;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Context
{
    public class StudentDbContext:IdentityDbContext<ApplicationUser>
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleSeedConfiguration());
            //modelBuilder.ApplyConfiguration(new UserSeedConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleSeedConfiguration());

            modelBuilder.Entity<Course>()
                .Property(c => c.Credits)
                .HasColumnType("decimal(5,2)"); 
        }

    }
}
