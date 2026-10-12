using DAL.Models;

namespace Contracts.Interfaces.Services;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}