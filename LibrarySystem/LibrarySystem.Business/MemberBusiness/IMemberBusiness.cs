using LibrarySystem.Shared.MemberData;

namespace LibrarySystem.Business.MemberBusiness
{
    public interface IMemberBusiness
    {
        Task<bool> AddMember(MemberDetails member);
        Task<bool> EditMembers(MemberDetails member);
        Task<MemberDetails> GetMemberDetails(int id);
        Task<List<MemberDetails>> GetMemberList(string? searchText = null);
    }
}
