namespace api.Repositories.Interfaces;

using api.Models;

public interface IUserRepository
{
    public Task AddUser(User user);
    public Task<IEnumerable<User>> GetUsers(int prev, int perPage);
    public Task<User> GetUserById(int id);
    public Task UpdateUser(User user);
    public Task DeleteUserById(int id);
    public Task<User> GetUserByEmail(string email);
}