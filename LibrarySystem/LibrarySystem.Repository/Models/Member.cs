using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Repository.Models
{
    public class Member : BaseEntity
    {
        [Key]
        public int MemberId { get; set; }
        [Required]
        public string? MemberName { get; set; }
        public long PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public DateTime JoinedDate { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public string? MembershipType { get; set; }
        public string? Status { get; set; }

    }
}
