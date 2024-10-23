using System;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace api.Repositories.Implementations;

public class ParkingGarageRepository : IParkingGarageRepository
{
    private readonly UCReviewsContext _dbContext;

    public ParkingGarageRepository(UCReviewsContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ParkingGarage>> GetAllParkingGarages(bool includeReviews)
    {
        var query = _dbContext.ParkingGarage.AsQueryable();

        if (includeReviews)
        {
            query = query.Include(g => g.Reviews).ThenInclude(r => r.User);
        }

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
