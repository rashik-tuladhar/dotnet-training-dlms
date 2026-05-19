using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibrarySystem.Repository.Models
{
    public class Member : BaseEntity
    {
        [Key]
        public int MemberId { get; set; }
        [Required]
        [MinLength(2)]
        public string? Name { get; set; }
        public string?phone{get; set; }
        public string? Email {get; set; }
        public string? Address{get; set; }
        public string?joinedDate {get; set; }
        public string?status{get; set; }
        public string? membershipType{get; set; }
        public string?ExpirationDate { get; set; }
    }
}
