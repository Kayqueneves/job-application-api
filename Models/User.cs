namespace JobApplicationAPI.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; private set; }
    public void SetPassword(string password)
    {
        // Implement password hashing here (e.g., using BCrypt)
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
    }
    public bool VerifyPassword(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
    }
    public List<Application> Applications { get; set; }
}

