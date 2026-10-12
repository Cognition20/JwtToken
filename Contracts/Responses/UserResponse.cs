namespace Contracts.Responses;

public record UserResponse(
    Guid Id,
    string FullName,
    string Group,
    int Variant,
    string Token);