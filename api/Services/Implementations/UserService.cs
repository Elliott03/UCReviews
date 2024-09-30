using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task AddUser(string email, string password, byte[] salt)
    {
        var temporaryUser = await _repository.GetUserByEmail(email);
        if (temporaryUser != null)
        {
            temporaryUser.Password = password;
            temporaryUser.Salt = salt;
            await _repository.UpdateUser(temporaryUser);
            return;
        }

        var user = new User
        {
            Email = email,
            Password = password,
            TimeCreated = DateTime.Now,
            Salt = salt,
            PasswordExpiration = DateTime.Now.Add(TimeSpan.FromMinutes(15))
        };

        await _repository.AddUser(user);
    }
    public async Task<User> GetUserByEmail(string email)
    {
        return await _repository.GetUserByEmail(email);
    }
    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _repository.GetAllUsers();
    }
    public async Task<User> GetUserById(int id)
    {
        return await _repository.GetUserById(id);
    }
    public async Task UpdateUser(User user)
    {
        await _repository.UpdateUser(user);
    }
    public async Task DeleteUserById(int id)
    {
        await _repository.DeleteUserById(id);
    }
}