using System.Collections;
using BookApp.Models;
using BookApp.Repository;

namespace BookApp.Services
{
    public class BookService : IBookService
    {
        readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<int> AddBook(Book book)
        {
            return await _bookRepository.AddBook(book);
        }

        public async Task<int> DeleteBookById(int id)
        {
            return await _bookRepository.DeleteBookById(id);
        }

        public async Task<IEnumerable> GetAllAuthors()
        {
            return await _bookRepository.GetAllAuthors();
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAllBooks();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _bookRepository.GetBookById(id);
        }

        public async Task<int> UpdateBook(Book book)
        {
            return await _bookRepository.UpdateBook(book);
        }
    }
}
