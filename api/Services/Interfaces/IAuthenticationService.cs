using api.Models;

namespace api.Services.Interfaces;

public interface IAuthenticationService
{
    public Task RegisterUser(string email);
    public string GenerateToken(User user);
    public Task<User> GetAuthenticatedUser(string email, string password);
    public bool IsJwtValid(string token);
}