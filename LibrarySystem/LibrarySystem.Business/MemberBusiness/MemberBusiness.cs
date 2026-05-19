using LibrarySystem.Repository.Models;
using LibrarySystem.Shared.MemberData;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Business.MemberBusiness
{
    public class MemberBusiness : IMemberBusiness
    {
        public Task<bool> AddMember(MemberDetails member)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditMember(MemberDetails member)
        {
            throw new NotImplementedException();
        }

        public Task<List<Member>> GetMemberList()
        {
            throw new NotImplementedException();
        }

        public Task<List<Member>> GetMemberList(string searchText)
        {
            throw new NotImplementedException();
        }
    }
}
