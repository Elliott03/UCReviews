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

    public async Task<IEnumerable<Dorm>> GetDorms(int prev, int perPage)
    {
        var query = _dbContext.Dorm.AsQueryable();
        perPage = int.Min(perPage, _paginationSettings.MaxPerPage);
        query = query.Where(g => g.Id > prev).Take(perPage);
        return await query.Include(b => b.Reviews).ThenInclude(r => r.User).ToListAsync();
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