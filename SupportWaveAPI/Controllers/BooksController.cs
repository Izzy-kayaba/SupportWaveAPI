using System;
using Microsoft.AspNetCore.Mvc;
using SupportWaveAPI.Models;
using SupportWaveAPI.Services;

namespace SupportWaveAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        // Retrieve all books
        // GET /api/books
        [HttpGet]
        public IActionResult GetBooks([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string searchQuery = "")
        {
            try
            {
                var books = _bookService.GetBooks(pageNumber, pageSize, searchQuery);
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }

        // Retrieve a specific book by ID
        // GET /api/books/{id}
        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(Guid id) 
        {
            try
            {
                var book = _bookService.GetBookById(id);
                if (book == null) 
                { 
                    return NotFound(); // 404 Not Found if the book does not exist
                }
                return Ok(book);
            }
            catch (Exception ex) {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }

        // Add a new book
        // POST /api/books
        [HttpPost]
        public ActionResult<Book> AddBook([FromBody] Book newBook)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // 400 Bad Request with validation errors
                }
                _bookService.AddBook(newBook);
                return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);

            }
            catch (Exception ex) {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }

        // Update an existing book
        // PUT /api/books/{id}
        [HttpPut("{id}")]
        public ActionResult<Book> UpdateBook(Guid id, [FromBody] Book updatedBook)
        {
            try
            {
                if (!ModelState.IsValid) 
                {
                    return BadRequest(ModelState); // 400 Bad Request with validation errors
                }

                var bookUpdated = _bookService.UpdateBook(id, updatedBook);

                if (!bookUpdated)
                {
                    return NotFound(); // 404 Not Found if the book does not exist
                }
                return NoContent(); // 204 No Content on successful update
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }


        // Delete a book
        // DELETE /api/books/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(Guid id)
        {
            try
            {
                var bookDeleted = _bookService.DeleteBook(id);
                if (!bookDeleted)
                {
                    return NotFound(); // 404 Not Found if the book does not exist
                }

                return NoContent(); // 204 No Content on successful deletion
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }


    }
}
