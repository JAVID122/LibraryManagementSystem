using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services.Interfaces
{
    public interface IMemberService
    {
        Task<IEnumerable<Member>> GetAllMembersAsync();

        Task<Member?> GetMemberByIdAsync(int id);

        Task<Member> AddMemberAsync(Member member);

        Task<bool> UpdateMemberAsync(int id, Member member);

        Task<bool> DeleteMemberAsync(int id);
    }
}