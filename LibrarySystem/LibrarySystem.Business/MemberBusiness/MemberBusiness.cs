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
                MemberName = member.MemberName,
                PhoneNumber = member.PhoneNumber,
                Address = member.Address,
                Email = member.Email,
            };
            return await _memberRepository.AddMember(memberEntity);
        }

        public async Task<bool> EditMember(MemberDetails member)
        {
            return await _memberRepository.EditMember(member);
        }

        public async Task<MemberDetails> GetMemberDetails(int memberId)
        {
            var memberData = await _memberRepository.GetMemberDetails(memberId);
            var memberDetails = new MemberDetails
            {
                MemberId = memberData.MemberId,
                MemberName = memberData.MemberName,
                PhoneNumber = memberData.PhoneNumber,
                Address = memberData.Address,
                Email = memberData.Email
            };
            return memberDetails;
        }

        public async Task<List<MemberDetails>> GetMemberList()
        {
            List<MemberDetails> memberList = new List<MemberDetails>();
            var members = await _memberRepository.GetMemberList();
            foreach (var member in members)
            {
                memberList.Add(new MemberDetails
                {
                    MemberId = member.MemberId,
                    MemberName = member.MemberName,
                    PhoneNumber = member.PhoneNumber,
                    Address = member.Address,
                    Email = member.Email
                });
            }
            return memberList;
        }
    }
}