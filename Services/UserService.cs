using Domains.DTOs.Users;
using Domains.Entities;
using Domains.Enums;
using Domains.Interfaces;
using Mapster;

namespace Services;

public class UserService : IUser
{
    private static List<User> _users;

    public UserService()
    {
        if (_users is null)
        {
            _users = new List<User>();
        }
    }

    private bool CheckUserExists(string email)
    {
        var user = _users.Any(q => q.Email == email);
        return user;
    }


    public OpStatus Add(AddUserRequest request)
    {
        try
        {
            var user = request.Adapt<User>();
            user.Id = Guid.NewGuid();

            var isUserExists = CheckUserExists(request.Email);

            if (isUserExists)
            {
                return OpStatus.AlreadyExists;
            }
            _users.Add(user);
            return OpStatus.Success;
        }
        catch (Exception)
        {
            return OpStatus.Failed;
        }
    }


    public OpStatus Delete()
    {
        return OpStatus.Success;
    }

    public User GetById(Guid id)
    {
        var userInfo = _users.FirstOrDefault(q => q.Id == id);
        return userInfo;
    }

    public LoginResponse Login(LoginRequest request)
    {
        throw new NotImplementedException();
    }

    public OpStatus Update(EditUserRequest request)
    {
        try
        {
            var userInfo = _users.FirstOrDefault(q => q.Id == request.Id);
            if (userInfo is null)
            {
                throw new Exception("User not found");
            }
            userInfo.Username = request.Username;
            userInfo.Email = request.Email;
            return OpStatus.Success;
        }
        catch (Exception)
        {
            return OpStatus.Failed;
        }
    }

    public List<User> GetAll()
    {
        return _users.OrderByDescending(q => q.CreatedDate)
            .ToList();
    }

    public List<User> Search(string? query)
    {
        var term = string.Empty;

        if (!string.IsNullOrEmpty(query))
        {
            term = query.ToLower().Trim();
        }

        var result = _users.Where(q => query == null || q.Username.ToLower().Contains(term) || q.Email.ToLower().Contains(term))
            .ToList();

        return result;

    }
}
