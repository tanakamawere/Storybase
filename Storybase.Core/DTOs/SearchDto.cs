using Storybase.Core.Models;

namespace Storybase.Core.DTOs;

public class SearchDto
{
    public IEnumerable<LiteraryWork> LiteraryWorks { get; set; }
    public IEnumerable<Writer> Writers { get; set; }
    public IEnumerable<Genre> Genres { get; set; }
}
