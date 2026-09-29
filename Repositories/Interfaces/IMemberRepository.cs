using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories.Interfaces
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAllAsync();

        Task<Member?> GetByIdAsync(int id);

        Task<Member> AddAsync(Member member);

        Task UpdateAsync(Member member);

        Task DeleteAsync(Member member);
    }
}