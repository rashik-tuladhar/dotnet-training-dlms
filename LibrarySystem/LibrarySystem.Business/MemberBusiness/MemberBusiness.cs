using LibrarySystem.Repository.Data;
using LibrarySystem.Repository.MemberRepository;
using LibrarySystem.Repository.Models;
using LibrarySystem.Shared.MemberData;
using LibrarySystem.Shared.PublicationData;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Business.MemberBusiness
{
    public class MemberBusiness : IMemberBusiness
    {

        private readonly IMemberRepository _memberRepository;
        public MemberBusiness(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public async Task<bool> AddMembers(MemberDetails member)
        {
            var memberEntity = new Repository.Models.Member
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
                CreatedDate = member.CreatedDate,
                CreatedBy = member.CreatedBy

            };
            return await  _memberRepository.AddMembers(memberEntity);



        }

        public bool DeleteMembers(int memberId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditMembers(MemberDetails member)
        {
            return await _memberRepository.EditMembers(member);
        }


        public async Task<MemberDetails> GetMemberDetails(int id)
        {
            var memberData = await _memberRepository.GetMembernDetails(id);
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
                CreatedDate = memberData.CreatedDate,
                CreatedBy = memberData.CreatedBy
            };
            return memberDetails;
        }

       

        public string MembershipDuration(int memberId)
        {
            throw new NotImplementedException();
        }

        public string MembershipType(int memberId)
        {
            throw new NotImplementedException();
        }

        public bool RenewMembership(int memberId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MemberDetails>> ViewAllList()
        {
            List<MemberDetails> memberList = new List<MemberDetails>();
            var members = await _memberRepository.ViewAllList();
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
                    CreatedDate = member.CreatedDate,
                    CreatedBy = member.CreatedBy
                });
            }

            return memberList;
        }

        public async Task<bool> RenewMembership(int memberId, int days)
        {
            return _memberRepository.RenewMembership(memberId, days);
        }
    }
}
