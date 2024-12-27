using Storybase.Core.Models;

namespace Storybase.Core.DTOs;

public class WriterProfileDto
{
    public Writer Writer { get; set; } = new();
    public List<LiteraryWork> LiteraryWorks { get; set; } = new();
}
