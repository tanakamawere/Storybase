using Storybase.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Storybase.Core.DTOs;

public class LiteraryWorkDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    [StringLength(200, ErrorMessage = "Title length can't be more than 200 characters.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Summary is required.")]
    [StringLength(1000, ErrorMessage = "Summary length can't be more than 1000 characters.")]
    public string Summary { get; set; }

    [Url(ErrorMessage = "Invalid URL format.")]
    public string CoverImageUrl { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime? LastModified { get; set; }

    [Required(ErrorMessage = "Type is required.")]
    public LiteraryWorkType Type { get; set; }

    public bool IsFree { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    [Range(0, 1, ErrorMessage = "FreePreviewPercentage must be between 0 and 1.")]
    public double FreePreviewPercentage { get; set; }
    public string Auth0Id { get; set; }

    public ICollection<Genre> Genres { get; set; }
    public ICollection<Chapter> Chapters { get; set; }

    public bool ProgressiveWriting { get; set; }
    public bool Completed { get; set; }
    public bool IsDeleted { get; set; } = false;
}
