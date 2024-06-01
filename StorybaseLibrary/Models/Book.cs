using System.ComponentModel.DataAnnotations.Schema;

namespace StorybaseLibrary.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int WriterId { get; set; }
    public Genre Genre { get; set; }
    public string CoverImageUrl { get; set; }
    public string Summary { get; set; }
    //This is price and should be correct to 2dp
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
    public Writer Writer { get; set; }
    public ICollection<Chapter> Chapters { get; set; }
}

public enum Genre
{
    Fiction,
    Mystery,
    Thriller,
    Romance,
    ScienceFiction,
    Fantasy,
    Horror,
    NonFiction,
    Biography,
    Memoir,
    History,
    SelfHelp,
    Poetry,
    Drama,
    Comedy,
    Adventure,
    Action,
    Crime,
    BiographyMemoir // Example of a combined genre
}
