using Storybase.Core.Models;

namespace Storybase.Core.DTOs;

public class WriterDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Auth0UserId { get; set; }
    public string? UserName { get; set; }
    public string? Bio { get; set; }
    public string? ContactInfo { get; set; }
}
