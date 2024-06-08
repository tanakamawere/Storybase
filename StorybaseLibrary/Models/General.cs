namespace StorybaseLibrary.Models;

public class General
{
    
}

public class SearchResults
{
    public string SearchTerm { get; set; }
    public List<Book> Books { get; set; }
    public List<Writer> Writers { get; set; }
}
