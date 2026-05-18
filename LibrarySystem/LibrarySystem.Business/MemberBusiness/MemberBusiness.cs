using LibrarySystem.Repository.MemberRepository;
using LibrarySystem.Shared.MemberData;

namespace LibrarySystem.Business.MemberBusiness
{
    public class MemberBusiness : IMemberBusiness
    {
        private readonly IMemberRepository _memberRepository;
        public MemberBusiness(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<bool> AddMember(MemberDetails member)
        {
            var memberEntity = new Repository.Models.Member
            {
                MemberName = string.IsNullOrEmpty(member.MemberName) ? "" : member.MemberName,
                Phone = member.Phone,
                Address = member.Address,
                Email = member.Email,
                JoinedDate = member.JoinedDate,
                ExpirationDate = member.ExpirationDate,
                Status = member.Status,
                CreatedBy = member.CreatedBy,
                ModifiedBy = member.ModifiedBy,
            };

            return await _memberRepository.AddMember(memberEntity);
        }

        public async Task<bool> EditMembers(MemberDetails member)
        {
            return await _memberRepository.EditMembers(member);
        }


        public async Task<MemberDetails> GetMemberDetails(int id)
        {
            var memberData = await _memberRepository.GetMemberDetails(id);
            var memberDetails = new MemberDetails
            {
                MemberId = memberData.MemberId,
                MemberName = memberData.MemberName,
                Phone = memberData.Phone,
                Address = memberData.Address,
                Email = memberData.Email,
                JoinedDate = memberData.JoinedDate,
                ExpirationDate = memberData.ExpirationDate,
                MembershipType = memberData.MembershipType,
                Status = memberData.Status,
                CreatedBy = memberData.CreatedBy,
                ModifiedBy = memberData.ModifiedBy,
            };
            return memberDetails;
        }

        public async Task<List<MemberDetails>> GetMemberList(string? searchText = null)
        {
            List<MemberDetails> memberList = new List<MemberDetails>();
            var members = await _memberRepository.GetMemberList(searchText);
            foreach (var member in members)
            {
                memberList.Add(new MemberDetails
                    {
                    MemberId = member.MemberId,
                    MemberName = member.MemberName,
                    Phone = member.Phone,
                    Address = member.Address,
                    Email = member.Email,
                    JoinedDate = member.JoinedDate,
                    ExpirationDate = member.ExpirationDate,
                    MembershipType = member.MembershipType,
                    Status = member.Status,
                    CreatedBy = member.CreatedBy,
                    ModifiedBy = member.ModifiedBy
                });
            }
            return memberList;
        }
    }
}
