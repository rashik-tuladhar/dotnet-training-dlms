using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibrarySystem.Shared.MemberData
{
    public class MemberDetails
    {
        public int MemberId { get; set; }
        [Required(ErrorMessage = "Please enter a valid member Id")]
        public string? Name { get; set; }
        [Required]
        public string? phone { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
