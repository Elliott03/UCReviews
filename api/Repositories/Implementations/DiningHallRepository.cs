
using api.Models;
using api.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public class DiningHallRepository : IDiningHallRepository
{
    private readonly UCReviewsContext _dbContext;
    private readonly PaginationSettings _paginationSettings;

    public DiningHallRepository(UCReviewsContext dbContext, IOptions<PaginationSettings> paginationSettings)
    {
        _dbContext = dbContext;
        _paginationSettings = paginationSettings.Value;
    }
    public async Task<IEnumerable<DiningHall>> GetDiningHalls(int prev, int perPage)
    {
        var query = _dbContext.DiningHall.AsQueryable();
        perPage = int.Min(perPage, _paginationSettings.MaxPerPage);
        query = query.Where(d => d.Id > prev).Take(perPage);
        return await query.Include(d => d.Reviews).ThenInclude(r => r.User).ToListAsync();
    }

    public async Task<DiningHall> GetDiningHall(string slug)
    {
        return await _dbContext.DiningHall.Include(b => b.Reviews).ThenInclude(r => r.User).Where(d => d.NameQueryParameter == slug).FirstOrDefaultAsync();
    }
}