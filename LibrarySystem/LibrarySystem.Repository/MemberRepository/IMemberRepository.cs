using LibrarySystem.Repository.Models;
using LibrarySystem.Shared.MemberData;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Repository.MemberRepository
{
    public interface IMemberRepository
    {
       Task<bool> AddMembers(Member member);
        Task<bool> EditMembers(MemberDetails member);
        bool DeleteMembers(int memberId);
         Task<List<Member>> ViewAllList();
        bool RenewMembership(int memberId, int days);
        string MembershipDuration(int memberId);
        string MembershipType(int memberId);
        Task<Member> GetMembernDetails (int id);
    }
}
