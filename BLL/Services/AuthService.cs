using Contracts.Interfaces.Services;
using Contracts.Requests;
using Contracts.Responses;
using DAL.Models;
using DAL.Repositories.Interfaces;


namespace Services.Services;

public class AuthService(IUserRepository userRepository, 
    IPasswordHasher passwordHasher,
    IJwtTokenGenerator jwtTokenGenerator) : IAuthenticationService
{
    public async Task<UserResponse> Register(RegisterUserRequest request)
    {
        var isExist = await userRepository.GetByFullNameAndGroupAsync(request.FullName, request.Group);
        
        if (isExist is not null)
        {
            throw new AggregateException("User already exists");
        }

        var passwordHash = passwordHasher.HashPassword(request.Password);
        
        var user = new User(
            request.FullName,
            request.Group,
            request.Variant,
            passwordHash
        );
        
        await userRepository.AddUserAsync(user);
        
        var token = jwtTokenGenerator.GenerateToken(user);
        
        return new UserResponse( user.Id,user.FullName, user.Group, user.Variant, token);
    }

    public async Task<UserResponse> Login(LoginRequest request)
    {
        var user = await userRepository.GetByFullNameAndGroupAsync(request.FullName, request.Group);
        
        if (user is null)
        {
            throw new AggregateException("User doesn't exists");
        }

        var isValidPassword = passwordHasher.VerifyHashedPassword(request.Password, user.PasswordHash);

        if (!isValidPassword)
        {
            throw new AggregateException("Invalid credentials");
        }
        
        var token = jwtTokenGenerator.GenerateToken(user);
        
        return new UserResponse(user.Id, user.FullName, user.Group, user.Variant, token);
    }
}

