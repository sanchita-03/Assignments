using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace StudentManagementSystem.Models
{
    public class Student 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        private string _name;
        [NotMapped] 
        public string Name
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
            set
            {
                _name = value;
            }
        }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string UserId { get; set; } 

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
