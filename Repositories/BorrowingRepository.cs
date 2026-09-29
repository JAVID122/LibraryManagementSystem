using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class BorrowingRepository : IBorrowingRepository
    {
        private readonly LibraryDbContext _context;

        public BorrowingRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Borrowing>> GetAllAsync()
        {
            return await _context.Borrowings
                .Include(b => b.Book)
                .Include(b => b.Member)
                .ToListAsync();
        }

        public async Task<Borrowing?> GetByIdAsync(int id)
        {
            return await _context.Borrowings
                .Include(b => b.Book)
                .Include(b => b.Member)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Borrowing> AddAsync(Borrowing borrowing)
        {
            await _context.Borrowings.AddAsync(borrowing);
            await _context.SaveChangesAsync();

            return borrowing;
        }

        public async Task UpdateAsync(Borrowing borrowing)
        {
            _context.Borrowings.Update(borrowing);
            await _context.SaveChangesAsync();
        }
    }
}