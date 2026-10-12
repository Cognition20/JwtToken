namespace DAL.Models;

public class User
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public string Group { get; private set; }
    public int Variant { get; private set; }
    public string PasswordHash { get; private set; }

    public User(string fullName, string group, int variant, string passwordHash)
    {
        Id = Guid.NewGuid();
        FullName = fullName;
        Group = group;
        Variant = variant;
        PasswordHash = passwordHash;
    }
}
    