
 
namespace Domains.Interfaces;

public interface IUser
{
    OpStatus Add(AddUserRequest request);
    OpStatus Update(EditUserRequest request);
    OpStatus Delete();
    User GetById(Guid id);
    List<User> GetAll();
    LoginResponse Login(LoginRequest request);
    List<User> Search(string? query);
}
