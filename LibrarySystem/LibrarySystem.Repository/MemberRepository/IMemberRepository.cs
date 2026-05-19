using LibrarySystem.Shared.MemberData;
using LibrarySystem.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;   
namespace LibrarySystem.Repository.MemberRepository
{
    public interface IMemberRepository
    {
        Task<bool> AddMember(Member member);
        Task<bool> EditMember(MemberDetails member);
        Task<List<Member>> GetMemberList();     
    }
}   
