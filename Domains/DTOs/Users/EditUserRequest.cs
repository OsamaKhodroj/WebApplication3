

namespace Domains.DTOs.Users;

public class EditUserRequest
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; } 
}
