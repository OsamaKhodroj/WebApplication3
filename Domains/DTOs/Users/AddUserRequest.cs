

namespace Domains.DTOs.Users;

public class AddUserRequest
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserTypeEnum UserType { get; set; }
}
