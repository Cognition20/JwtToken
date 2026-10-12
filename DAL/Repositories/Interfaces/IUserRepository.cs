using DAL.Models;

namespace DAL.Repositories.Interfaces;

public interface IUserRepository
{
    Task AddUserAsync(User user);
    Task<User?> GetByFullNameAndGroupAsync(string fullName, string groupName);
}