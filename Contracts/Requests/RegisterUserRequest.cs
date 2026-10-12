namespace Contracts.Requests;

public record RegisterUserRequest(
    string FullName,
    string Group,
    int Variant,
    string Password);