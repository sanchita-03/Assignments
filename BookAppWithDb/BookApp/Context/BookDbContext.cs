using BookApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Context
{
    public class BookDbContext:DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options):base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
