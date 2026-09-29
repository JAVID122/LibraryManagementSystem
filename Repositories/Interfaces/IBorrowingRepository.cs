using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories.Interfaces
{
    public interface IBorrowingRepository
    {
        Task<IEnumerable<Borrowing>> GetAllAsync();

        Task<Borrowing?> GetByIdAsync(int id);

        Task<Borrowing> AddAsync(Borrowing borrowing);

        Task UpdateAsync(Borrowing borrowing);
    }
}