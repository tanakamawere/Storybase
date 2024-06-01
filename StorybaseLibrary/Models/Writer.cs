namespace StorybaseLibrary.Models;

public class Writer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Bio { get; set; }
    public string ContactInfo { get; set; }
    public ICollection<Book> Books { get; set; }
}
