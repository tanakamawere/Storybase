namespace Storybase.Core.Models;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Many-to-Many relationship
    public ICollection<LiteraryWork> LiteraryWorks { get; set; } = new List<LiteraryWork>();
}

