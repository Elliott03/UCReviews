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

    public async Task<IEnumerable<ParkingGarage>> GetParkingGarages(bool includeReviews, int prev, int perPage)
    {
        var query = _dbContext.ParkingGarage.AsQueryable();

        if (includeReviews)
        {
            query = query.Include(g => g.Reviews).ThenInclude(r => r.User);
        }

        perPage = int.Min(perPage, _paginationSettings.MaxPerPage);
        query = query.Where(g => g.Id > prev).Take(perPage);
        return await query.ToListAsync();
    }

    public async Task<ParkingGarage> GetParkingGarage(string slug, bool includeReviews)
    {
        return await HandleGetGarage(includeReviews, g => g.Slug == slug);
    }

    public async Task<ParkingGarage> GetParkingGarage(int id, bool includeReviews)
    {
        return await HandleGetGarage(includeReviews, g => g.Id == id);
    }


    private async Task<ParkingGarage> HandleGetGarage(bool includeReviews, Expression<Func<ParkingGarage, bool>> predicate)
    {
        var query = _dbContext.ParkingGarage.AsQueryable();

        if (includeReviews)
        {
            query = query.Include(g => g.Reviews).ThenInclude(r => r.User);
        }

        return await query.Where(predicate).FirstOrDefaultAsync();
    }
}
