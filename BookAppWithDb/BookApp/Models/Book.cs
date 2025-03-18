using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookApp.Models
{
    public class Book
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [MaxLength(60)]
        [Required]
        public string Title { get; set; }
        [Required]
        public string Isbn { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
