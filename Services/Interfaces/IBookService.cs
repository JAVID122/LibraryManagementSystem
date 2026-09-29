using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();

        Task<Book?> GetBookByIdAsync(int id);

        Task<Book> AddBookAsync(Book book);

        Task<bool> UpdateBookAsync(int id, Book book);

        Task<(bool Success, string Message)> DeleteBookAsync(int id);
    }
}