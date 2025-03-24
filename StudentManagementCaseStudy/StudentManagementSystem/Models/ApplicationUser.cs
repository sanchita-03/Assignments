using Microsoft.AspNetCore.Identity;

namespace StudentManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Student Student { get; set; }
    }
}
    