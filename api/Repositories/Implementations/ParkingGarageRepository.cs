using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using api.Settings;
using Microsoft.Extensions.Options;

namespace api.Repositories.Implementations;

public class ParkingGarageRepository : IParkingGarageRepository
{
    private readonly UCReviewsContext _dbContext;
    private readonly PaginationSettings _paginationSettings;

    public ParkingGarageRepository(UCReviewsContext dbContext, IOptions<PaginationSettings> paginationSettings)
    {
        _dbContext = dbContext;
        _paginationSettings = paginationSettings.Value;
    }

    public async Task<IEnumerable<ParkingGarage>> GetParkingGarages(int prev, int perPage, string? searchTerm = null)
    {
    var query = _dbContext.ParkingGarage.AsQueryable();

    if (!string.IsNullOrWhiteSpace(searchTerm))
    {
        query = query.Where(g => g.Name.Contains(searchTerm)); 
    }

    perPage = Math.Min(perPage, _paginationSettings.MaxPerPage);
    query = query.Where(g => g.Id > prev).Take(perPage);
    query = query.Include(rs => rs.ReviewSummary);

    return await query.ToListAsync();
    }

    public async Task<ParkingGarage> GetParkingGarage(string slug)
    {
        return await HandleGetGarage(g => g.Slug == slug);
    }

    public async Task<ParkingGarage> GetParkingGarage(int id)
    {
        return await HandleGetGarage(g => g.Id == id);
    }

    private async Task<ParkingGarage> HandleGetGarage(Expression<Func<ParkingGarage, bool>> predicate)
    {
        var query = _dbContext.ParkingGarage.AsQueryable();
        query = query.Include(rs => rs.ReviewSummary);
        return await query.Where(predicate).FirstOrDefaultAsync();
    }
}