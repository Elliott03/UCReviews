using api.Models;
using api.Repositories.Interfaces;
using api.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace api.Repositories.Implementations;

public class DormRepository : IDormRepository
{
    private readonly UCReviewsContext _dbContext;
    private readonly PaginationSettings _paginationSettings;
    public DormRepository(UCReviewsContext dbContext, IOptions<PaginationSettings> paginationSettings)
    {
        _dbContext = dbContext;
        _paginationSettings = paginationSettings.Value;
    }

    public async Task<IEnumerable<Dorm>> GetDorms(int prev, int perPage, string? searchTerm = null)
    {
    var query = _dbContext.Dorm.AsQueryable();

    if (!string.IsNullOrWhiteSpace(searchTerm))
    {
        query = query.Where(g => g.Name.Contains(searchTerm));
    }

    perPage = Math.Min(perPage, _paginationSettings.MaxPerPage);
    query = query.Where(g => g.Id > prev).Take(perPage);
    query = query.Include(b => b.ReviewSummary);

    return await query.ToListAsync();
    }

    public async Task<Dorm> GetDorm(string queryParam)
    {
        var query = _dbContext.Dorm.AsQueryable();
        query = query.Include(b => b.ReviewSummary);
        return await query.Where(g => g.NameQueryParameter == queryParam).FirstOrDefaultAsync();
    }

    public async Task<Dorm> GetDorm(int id)
    {
        var query = _dbContext.Dorm.AsQueryable();
        query = query.Include(b => b.ReviewSummary);
        return await query.Where(g => g.Id == id).FirstOrDefaultAsync();
    }

}