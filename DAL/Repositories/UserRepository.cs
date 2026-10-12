using DAL.Models;
using DAL.Persistance;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class UserRepository(AppDbContext dbContext) : IUserRepository
{
    public async Task AddUserAsync(User user)
    {
        await dbContext.Users.AddAsync(user);
        await dbContext.SaveChangesAsync();
    }

    public async Task<User?> GetByFullNameAndGroupAsync(string fullName, string groupName)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync( u => u.FullName == fullName && u.Group== groupName);
        return user;
    }
}