﻿using System.Collections;
using BookApp.Models;

namespace BookApp.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<int> AddBook(Book book);
        Task<IEnumerable> GetAllAuthors();
        Task<Book> GetBookById(int id);
        Task<int> DeleteBookById(int id);
        Task<int> UpdateBook(Book book);
    }
}
