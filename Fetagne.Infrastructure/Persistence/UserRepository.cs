namespace Fetagne.Infrastructure.Persistence;
using Fetagne.Application.Common.Interface.Persistence;
using Fetagne.Domain.Entities;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new List<User>();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }
}