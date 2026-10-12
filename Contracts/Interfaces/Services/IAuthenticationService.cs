using Contracts.Requests;
using Contracts.Responses;

namespace Contracts.Interfaces.Services;

public interface IAuthenticationService
{
    Task<UserResponse> Register(RegisterUserRequest request);
    Task<UserResponse> Login(LoginRequest request);
}