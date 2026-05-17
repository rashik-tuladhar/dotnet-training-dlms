using LibrarySystem.Repository.Models;
using LibrarySystem.Shared.MemberData;

namespace LibrarySystem.Repository.MemberRepository
{
    public interface IMemberRepository
    {
        Task<bool> AddMember(Member member);
        Task<bool> EditMembers(MemberDetails member);
        Task<Member> GetMemberDetails(int id);
        Task<List<Member>> GetMemberList();
    }
}