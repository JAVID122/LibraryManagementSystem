using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/books
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();

            return Ok(books);
        }

        // GET: api/books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return NotFound("Book not found.");
            }

            return Ok(book);
        }

        // POST: api/books
        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            var createdBook = await _bookService.AddBookAsync(book);

            return CreatedAtAction(
                nameof(GetBookById),
                new { id = createdBook.Id },
                createdBook);
        }

        // PUT: api/books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(
            int id,
            Book book)
        {
            var result =
                await _bookService.UpdateBookAsync(id, book);

            if (!result)
            {
                return NotFound("Book not found.");
            }

            return NoContent();
        }

        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBookAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }
    }
}