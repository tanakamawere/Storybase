namespace Storybase.Core.Models;

public class User
{
    public int Id { get; set; }
    public string Auth0UserId { get; set; } // Auth0 identifier.

    public string Name { get; set; }
    public string Email { get; set; }

    public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}

