
using api.Models;
using api.Repositories.Interfaces;
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
        query = query.Include(d => d.Reviews).ThenInclude(r => r.User);
        query = query.Include(d => d.ReviewSummary);
        return await query.ToListAsync();
    }

    public async Task<DiningHall> GetDiningHall(string slug)
    {
        var query = _dbContext.DiningHall.AsQueryable();
        query = query.Include(b => b.Reviews).ThenInclude(r => r.User).Where(d => d.NameQueryParameter == slug);
        return await query.FirstOrDefaultAsync();
    }
}