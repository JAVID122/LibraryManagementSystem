using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Interfaces;
using LibraryManagementSystem.Services.Interfaces;

namespace LibraryManagementSystem.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            book.IsAvailable = true;

            return await _bookRepository.AddAsync(book);
        }

        public async Task<bool> UpdateBookAsync(int id, Book book)
        {
            var existingBook = await _bookRepository.GetByIdAsync(id);

            if (existingBook == null)
            {
                return false;
            }

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            //existingBook.ISBN = book.ISBN;
            existingBook.PublishedYear = book.PublishedYear;

            await _bookRepository.UpdateAsync(existingBook);

            return true;
        }

        public async Task<(bool Success, string Message)>
      DeleteBookAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
            {
                return (false, "Book not found.");
            }

            if (!book.IsAvailable)
            {
                return (false, "Cannot delete a borrowed book.");
            }

            await _bookRepository.DeleteAsync(book);

            return (true, "Book deleted successfully.");
        }
    }
}