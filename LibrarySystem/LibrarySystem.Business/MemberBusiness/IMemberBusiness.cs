using LibrarySystem.Repository.Models;
using LibrarySystem.Shared.MemberData;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Business.MemberBusiness
{
    public interface IMemberBusiness
    {
        Task<bool> AddMember(MemberDetails members);
        Task<bool> EditMember(MemberDetails member);
        Task<List<Member>> GetMemberList(string searchText);
    }
}
