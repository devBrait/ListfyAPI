namespace Listfy_Application.Services;

public class SecurityService
{
    public string HashPassword(string password)
    {
        string hash = BCrypt.Net.BCrypt.HashPassword(password);
        return hash;
    }

    public bool VerifyPassword(string password, string storedHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, storedHash);
    }
}