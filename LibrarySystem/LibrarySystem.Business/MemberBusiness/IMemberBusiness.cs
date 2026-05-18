using LibrarySystem.Shared.MemberData;

namespace LibrarySystem.Business.MemberBusiness
{
    public interface IMemberBusiness
    {
        Task<bool> AddMember(MemberDetails member);
        Task<bool> EditMember(MemberDetails member);
        Task<MemberDetails> GetMemberDetails(int memberId);
        Task<List<MemberDetails>> GetMemberList();
    }
}
