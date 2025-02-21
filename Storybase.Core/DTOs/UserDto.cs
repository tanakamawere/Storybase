namespace Storybase.Core.DTOs;

public class UserDto
{
    public string Auth0UserId { get; set; } // Auth0 identifier.

    public string Name { get; set; }
    public string Email { get; set; }
    public string ImageUrl { get; set; }
}
