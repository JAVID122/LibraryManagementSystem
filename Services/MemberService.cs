using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Interfaces;
using LibraryManagementSystem.Services.Interfaces;

namespace LibraryManagementSystem.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            return await _memberRepository.GetAllAsync();
        }

        public async Task<Member?> GetMemberByIdAsync(int id)
        {
            return await _memberRepository.GetByIdAsync(id);
        }

        public async Task<Member> AddMemberAsync(Member member)
        {
            return await _memberRepository.AddAsync(member);
        }

        public async Task<bool> UpdateMemberAsync(int id, Member member)
        {
            var existingMember =
                await _memberRepository.GetByIdAsync(id);

            if (existingMember == null)
            {
                return false;
            }

            existingMember.Name = member.Name;
            existingMember.Email = member.Email;
            existingMember.PhoneNumber = member.PhoneNumber;

            await _memberRepository.UpdateAsync(existingMember);

            return true;
        }

        public async Task<bool> DeleteMemberAsync(int id)
        {
            var member =
                await _memberRepository.GetByIdAsync(id);

            if (member == null)
            {
                return false;
            }

            await _memberRepository.DeleteAsync(member);

            return true;
        }
    }
}