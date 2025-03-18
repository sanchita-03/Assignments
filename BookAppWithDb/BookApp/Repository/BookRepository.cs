using System.Collections;
using BookApp.Context;
using BookApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Repository
{
    public class BookRepository : IBookRepository
    { 
        readonly BookDbContext _bookDbContext;
        public BookRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public async Task<int> AddBook(Book book)
        {
            _bookDbContext.Books.Add(book);
            return await _bookDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteBookById(int id)
        {
            Book book= await _bookDbContext.Books.Include(a => a.Author).FirstOrDefaultAsync(b => b.BookId == id);
            if (book == null)
            {
                return 0;
            }
            _bookDbContext.Books.Remove(book);
            return await _bookDbContext.SaveChangesAsync(); 
        }

        public async Task<IEnumerable> GetAllAuthors()
        {
            return await _bookDbContext.Authors.ToListAsync();
             
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookDbContext.Books.Include(a=>a.Author).ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _bookDbContext.Books.Include(a=>a.Author).FirstOrDefaultAsync(b=>b.BookId==id);
        }

        public async Task<int> UpdateBook(Book book)
        {
            Book updateBook = await GetBookById(book.BookId);
            updateBook.Title = book.Title;
            updateBook.Isbn = book.Isbn;
            updateBook.AddedDate = book.AddedDate;
            updateBook.AuthorId= book.AuthorId;
            _bookDbContext.Books.Update(updateBook);
            return await _bookDbContext.SaveChangesAsync();
            
        }
    }
}
