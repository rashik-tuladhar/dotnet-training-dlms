using LibrarySystem.Repository.Data;
using LibrarySystem.Repository.Models;
using LibrarySystem.Shared.LocationData;
using LibrarySystem.Shared.MemberData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Repository.MemberRepository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ApplicationDbContext _context;

        public MemberRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddMember(Member member)
        {
            await _context.Members.AddAsync(member);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;
            return false;
        }

        public async Task<bool> EditMember(MemberDetails member)
        {
            var memberDetails = _context.Members.FirstOrDefault(x => x.MemberId == member.MemberId);
            if (memberDetails != null)
            {
                memberDetails.MemberName = member.MemberName;
                memberDetails.PhoneNumber = member.PhoneNumber;
                memberDetails.Address = member.Address;
                memberDetails.Email = member.Email;
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                    return true;
            }
            return false;
        }

        public async Task<Member> GetMemberDetails(int id)
        {
            var memberDetails = await _context.Members.AsNoTracking().FirstOrDefaultAsync(x => x.MemberId == id);
            return memberDetails;
        }

        public async Task<List<Member>> GetMemberList()
        {
            var memberList = await _context.Members.AsNoTracking().OrderByDescending(x => x.MemberId).ToListAsync();
            return memberList;
        }
    }
}
