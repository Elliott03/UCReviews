using System.Collections;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly UCReviewsContext _dbContext;
    public UserRepository(UCReviewsContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddUser(User user)
    {
        _dbContext.Add(user);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<User> GetUserByEmail(string email) 
    {
        return await _dbContext.User.FirstOrDefaultAsync(u => u.Email == email);
    }
    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _dbContext.User.ToListAsync();
    }

    public async Task<User> GetUserById(int id)
    {
        return await _dbContext.User.Where(u => u.Id == id).FirstOrDefaultAsync();
    }
    public async Task UpdateUser(User user)
    {
        _dbContext.User.Update(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteUserById(int id)
    {
        User userToDelete = await _dbContext.User.FindAsync(id);
        _dbContext.User.Remove(userToDelete);
        await _dbContext.SaveChangesAsync();
    }
}