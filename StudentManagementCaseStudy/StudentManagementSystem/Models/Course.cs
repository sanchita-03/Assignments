using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        [Required]
        [MaxLength(40)]
        public string CourseName { get; set; } 
        public string Description { get; set; } 
        [Required]
        public decimal Credits { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
