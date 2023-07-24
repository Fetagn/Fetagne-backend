namespace Fetagne.Application.Common.Interface.Persistence;
using Fetagne.Domain.Entities;

public interface IUserRepository
{
    User? GetByEmail(string email);
    void Add(User user);
}