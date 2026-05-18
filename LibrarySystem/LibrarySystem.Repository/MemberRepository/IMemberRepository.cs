using LibrarySystem.Repository.Models;
using LibrarySystem.Shared.LocationData;
using LibrarySystem.Shared.MemberData;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Repository.MemberRepository
{
    public interface IMemberRepository
    {
        Task<bool> AddMember(Member member);
        Task<bool> EditMember(MemberDetails member);
        Task<Member> GetMemberDetails(int memberId);
        Task<List<Member>> GetMemberList();
    }
}
