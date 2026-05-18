using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Shared.MemberData
{
    public class MemberDetails
    {
        public int MemberId { get; set; }
        [Required(ErrorMessage = "Please enter the member name,")]
        [MinLength(5, ErrorMessage = "Member name must be at least 5 characters.")]
        [StringLength(100, ErrorMessage="Member name cannot exceed 100 characters.")]
        public string? MemberName { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        [StringLength(20)]
        public string? Phone { get; set; }
        [StringLength(200)]
        public string? Address { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(100)]
        public string? Email { get; set; }
        public DateTime JoinedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        [Required]
        public MembershipType MembershipType { get; set; }
        [Required]
        public MemberStatus Status { get; set; }
        [StringLength(100)]
        public string? CreatedBy { get; set; }
        [StringLength(100)]
        public string? ModifiedBy { get; set; }
    }
}
