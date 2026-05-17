using LibrarySystem.Repository.Data;
using LibrarySystem.Repository.Models;
using LibrarySystem.Shared.MemberData;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> EditMembers(MemberDetails member)
        {
            var memberDetails = _context.Members.FirstOrDefault(x => x.MemberId == member.MemberId);

            if (memberDetails != null)
            {
                memberDetails.MemberName = member.MemberName ?? string.Empty;
                memberDetails.Phone = member.Phone;
                memberDetails.Address = member.Address;
                memberDetails.Email = member.Email;
                memberDetails.JoinedDate = member.JoinedDate;
                memberDetails.ExpirationDate = member.ExpirationDate;
                memberDetails.MembershipType = member.MembershipType;
                memberDetails.Status = member.Status;
                memberDetails.CreatedBy = member.CreatedBy;
                memberDetails.ModifiedBy = member.ModifiedBy;

                var result = await _context.SaveChangesAsync();

                if (result > 0)
                    return true;
            }

            return false;
        }

        public async Task<Member> GetMemberDetails(int id)
        {
            var memberDetails = await _context.Members
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.MemberId == id);

            return memberDetails;
        }

        public async Task<List<Member>> GetMemberList()
        {
            var memberList = await _context.Members
                .AsNoTracking()
                .OrderByDescending(x => x.MemberId)
                .ToListAsync();

            return memberList;
        }
    }
}