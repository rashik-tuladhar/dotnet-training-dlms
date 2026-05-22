using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibrarySystem.Shared.BookData
{
    public class BookDetails
    {
        public int BookId { get; set; }
        [Required]
        [StringLength(500)]
        public string Name { get; set; }
        [Required]
        [StringLength(500)]
        public string Author { get; set; }
        
        public List<SelectListItem> AuthorList { get; set; } 
        [Required]
        [StringLength(500)]
        public string Publication { get; set; }
        [Required]
        [StringLength(500)]
        public string Category { get; set; }
        [Required]
        [StringLength(200)]
        public string Isbn { get; set; }
        [Required]
        [Range(1, 50)]
        public int TotalCopies { get; set; }
        [Required]
        [Range(1, 50)]
        public int AvailableCopies { get; set; }
        [Required]
        [StringLength(500)]
        public string Edition { get; set; }
        public string? User { get; set; }
        public string? Status { get; set; }
    }
}
