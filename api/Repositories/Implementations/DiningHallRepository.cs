
using api.Models;
using Microsoft.EntityFrameworkCore;

public class DiningHallRepository : IDiningHallRepository
{
    private readonly UCReviewsContext _dbContext;
    public DiningHallRepository(UCReviewsContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<DiningHall>> GetAllDiningHalls()
    {
        return await _dbContext.DiningHall.Include(d => d.Reviews).ThenInclude(r => r.User).ToListAsync();
    }

    public async Task<DiningHall> GetDiningHall(string queryParam)
    {
        return await _dbContext.DiningHall.Where(d => d.NameQueryParameter == queryParam).FirstOrDefaultAsync();
    }
}