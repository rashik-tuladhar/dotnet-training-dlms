using LibrarySystem.Repository.Models;
using LibrarySystem.Shared.MemberData;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Business.MemberBusiness
{
    public interface IMemberBusiness
    {
       Task< bool> AddMembers(MemberDetails member);
        Task<bool> EditMembers(MemberDetails member);
        bool DeleteMembers(int memberId);
        Task<List<MemberDetails>> ViewAllList();
        Task<bool> RenewMembership(int memberId, int days);
        string MembershipDuration(int memberId);
        string MembershipType(int memberId);
        Task<MemberDetails> GetMemberDetails(int id);
    }
}
