namespace api.Services.Interfaces;
using api.Models;
public interface IUserService
{
    public Task AddUser(string email, string password, byte[] salt);
    public Task<IEnumerable<User>> GetUsers();
    public Task<User> GetUserById(int id);
    public Task UpdateUser(User user);
    public Task DeleteUserById(int id);
    public Task<User> GetUserByEmail(string email);
}