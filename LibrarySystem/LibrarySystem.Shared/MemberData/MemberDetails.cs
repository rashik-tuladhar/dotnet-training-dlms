using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace LibrarySystem.Shared.MemberData;

public class MemberDetails
{
    public int MemberId { get; set; }
    [Required]
    public string? MemberName { get; set; }
    [Required]
    public long PhoneNumber { get; set; }
    [Required]
    public string? Address { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public DateTime JoinedDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    [Required]
    public string? MembershipType { get; set; }
    public string? Status { get; set; }
    public string? User { get; set; }

    public MemberDetails()
    {
        this.ExpirationDate = JoinedDate.AddDays(15);
    }
}