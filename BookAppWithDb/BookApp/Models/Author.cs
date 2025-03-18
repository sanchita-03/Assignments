using System.ComponentModel.DataAnnotations;

namespace BookApp.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required]
        public string AuthorName { get; set; }
        public ICollection<Book> Book { get; set; }
    }
}
