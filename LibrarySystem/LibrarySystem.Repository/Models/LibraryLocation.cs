using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Repository.Models;

public class LibraryLocation : BaseEntity
{
    [Key]
    public int LocationId { get; set; }

    [Required]
    public string Aisle { get; set; }

    [Required]
    public string Shelf { get; set; }

    [Required]
    public string? Section { get; set; }

    [Required]
    public string? Floor { get; set; }

    [Required]

    public string? Description { get; set; }
}
