namespace StorybaseLibrary.Models;

public class StorybaseUser
{
    public int Id { get; set; }
    public string UserGuid { get; set; } = Guid.NewGuid().ToString();
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public string PasswordHash { get; set; }
    public UserRole Role { get; set; } = UserRole.Reader; // Default role
}

//enum for user roles
public enum UserRole
{
    Reader,
    Writer,
    Admin
}

// Register User DTO
public class RegisterUserDto
{
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}

// Login User DTO
public class LoginUserRequest
{
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}
public class LoginResponse
{
    public string Message { get; set; }
    public string Token { get; set; }
}

