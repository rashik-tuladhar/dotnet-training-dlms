using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibrarySystem.Shared.MemberData
{
    public class MemberDetails
    {

        public int MemberId { get; set; }
        [Required(ErrorMessage = "Member Name Is Required")]
        public string MemberName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public DateOnly JoinedDate { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public string? MembershipType { get; set; }
        public string? Status { get; set; }
        public DateOnly CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateOnly ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
