using LibrarySystem.Repository.Data;
using LibrarySystem.Repository.Models;
using LibrarySystem.Shared.MemberData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Numerics;
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

        public async Task<bool> AddMembers(Member member)
        {
            await _context.Members.AddAsync(member);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;
            return false;
        }

        public bool DeleteMembers(int memberId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditMembers(Member member)
        {
            var memberDetails = await _context.Members.FirstOrDefaultAsync(x => x.MemberId == member.MemberId);
            if (memberDetails != null)
            {
                memberDetails.MemberName = member.MemberName;
                memberDetails.Phone = member.Phone;
                memberDetails.Address = member.Address;
                memberDetails.Email = member.Email;
                memberDetails.JoinedDate = member.JoinedDate;
                memberDetails.ExpirationDate = member.ExpirationDate;
                memberDetails.MembershipType = member.MembershipType;
                memberDetails.Status = member.Status;
                memberDetails.ModifiedBy = member.ModifiedBy;
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                    return true;
            }
            return false;
        }

        public async Task<Member> GetMembernDetails(int id)
        {
            var memberDetails = await _context.Members.FirstOrDefaultAsync(x => x.MemberId == id);
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

        public async  Task<bool> RenewMembership(int memberId, int days)
        {
            var member =  await _context.Members.FindAsync( memberId);

            if (member == null)
            {
                return false;
            }

            member.ExpirationDate = member.ExpirationDate.AddDays(days);

           await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Member>> ViewAllList()
        {
            var memberList = await _context.Members.AsNoTracking().OrderByDescending(x => x.MemberId).ToListAsync();
            



            return memberList;
        }

        
    }
}
