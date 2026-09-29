using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services.Interfaces
{
    public interface IBorrowingService
    {
        Task<IEnumerable<Borrowing>> GetAllBorrowingsAsync();

        Task<Borrowing?> GetBorrowingByIdAsync(int id);

        Task<(bool Success, string Message, Borrowing? Borrowing)>
            BorrowBookAsync(int bookId, int memberId);

        Task<(bool Success, string Message)>
            ReturnBookAsync(int borrowingId);
    }
}