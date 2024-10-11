using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Implementations;

public class DormRepository : IDormRepository
{
    private readonly UCReviewsContext _dbContext;
    public DormRepository(UCReviewsContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Dorm>> GetAllDorms()
    {
        return await _dbContext.Dorm.ToListAsync();
    }

    public async Task<Dorm> GetDorm(string queryParam)
    {
        return await _dbContext.Dorm.Include(b => b.Reviews).ThenInclude(r => r.User).Where(b => b.NameQueryParameter == queryParam).FirstOrDefaultAsync();
    }

    public async Task<Dorm> GetDormById(int id)
    {
        return await _dbContext.Dorm.Include(b => b.Reviews).Where(b => b.Id == id).FirstOrDefaultAsync();
    }
}