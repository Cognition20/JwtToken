namespace Contracts.Requests;

public record LoginRequest(
    string FullName,
    string Group,
    string Password);