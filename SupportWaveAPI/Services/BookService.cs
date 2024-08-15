using SupportWaveAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;

namespace SupportWaveAPI.Services
{
    public class BookService : IBookService
    {
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "books.json");

        // Fetch a paginated list of books (optionally filtered)
        public List<Book> GetBooks(int pageNumber, int pageSize, string searchQuery)
        {
            var books = GetBooksFromFile();
            if (!string.IsNullOrEmpty(searchQuery)) 
            { 
                // Convert the search for case-insensitive comparison
                searchQuery = searchQuery.ToLower();

                // If searchQuery is provided, filter the books according to either title or author
                books = books.Where(b => b.Title.ToLower().Contains(searchQuery) || b.Author.ToLower().Contains(searchQuery)).ToList();
            }

            return books
                .Skip((pageNumber - 1) * pageSize) // Skip books from previous page
                .Take(pageSize) // Take only books from the current page
                .ToList(); // Convert the returned results
             }

        // Fetch a specific book by ID
        public Book GetBookById(Guid id)
        {
            var books = GetBooksFromFile();
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)  return null;
            return book;
        }

        // Update an existing book if found
        public bool UpdateBook(Guid id, Book updatedBook)
        {
            var books = GetBooksFromFile();
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null) return false;

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.PublishedDate = updatedBook.PublishedDate;
            book.ISBN = updatedBook.ISBN;
            SaveBooksToFile(books);
            return true;
        }

        // Add a new book to the collection
        public void AddBook(Book newBook)
        {
            var books = GetBooksFromFile();
            newBook.Id = Guid.NewGuid(); // Generate a new GUID for the book
            books.Add(newBook);
            SaveBooksToFile(books);
        }

        public bool DeleteBook(Guid id)
        {
            var books = GetBooksFromFile();
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null) return false;

            books.Remove(book);
            SaveBooksToFile(books);
            return true;
        }


        // HELPER METHODS
        // Method to read books from JSON file
        private List<Book> GetBooksFromFile() {
            var jsonData = File.ReadAllText(_filePath);

            // return available data or an empty new list
            return JsonConvert.DeserializeObject<List<Book>>(jsonData) ?? new List<Book>();
        }

        // Method to save the updated list of books to JSON file
        private void SaveBooksToFile(List<Book> books)
        {
            var jsonData = JsonConvert.SerializeObject(books, Formatting.Indented);

            File.WriteAllText(_filePath, jsonData);
        }

    }
}
