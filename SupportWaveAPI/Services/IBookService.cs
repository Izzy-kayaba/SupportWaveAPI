using System;
using System.Collections.Generic;

using SupportWaveAPI.Models;

namespace SupportWaveAPI.Services
{
    public interface IBookService
    {
        List<Book> GetBooks(int pageNumber, int pageSize, string? searchQuery);

        Book GetBookById(Guid id);

        void AddBook(Book newBook);

        bool UpdateBook(Guid id, Book updatedBook);

        bool DeleteBook(Guid id);
    }
}
