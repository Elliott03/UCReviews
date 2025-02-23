
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
    public async Task<IEnumerable<DiningHall>> GetDiningHalls(int prev, int perPage, string? searchTerm = null)
{
    var query = _dbContext.DiningHall.AsQueryable();

    if (!string.IsNullOrWhiteSpace(searchTerm))
    {
        query = query.Where(d => d.Name.Contains(searchTerm));
    }

    perPage = Math.Min(perPage, _paginationSettings.MaxPerPage);
    query = query.Where(d => d.Id > prev).Take(perPage);
    query = query.Include(d => d.ReviewSummary);

    return await query.ToListAsync();
}

    public async Task<DiningHall> GetDiningHall(string slug)
    {
        var query = _dbContext.DiningHall.AsQueryable();
        query = query.Include(b => b.ReviewSummary);
        return await query.Where(d => d.NameQueryParameter == slug).FirstOrDefaultAsync();
    }
}