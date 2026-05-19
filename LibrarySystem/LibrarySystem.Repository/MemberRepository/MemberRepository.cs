using LibrarySystem.Repository.Models;
using LibrarySystem.Shared.MemberData;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Repository.MemberRepository
{
    public class MemberRepository : IMemberRepository
    {
        public Task<bool> AddMember(Member member)
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
    }
}
