namespace api.Repositories.Implementations;

using api.Models;
using api.Repositories.Interfaces;
using api.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public class ReviewRepository : IReviewRepository
{
    private readonly UCReviewsContext _dbContext;
    private readonly PaginationSettings _paginationSettings;

    public ReviewRepository(UCReviewsContext dbContext, IOptions<PaginationSettings> paginationSettings)
    {
        _dbContext = dbContext;
        _paginationSettings = paginationSettings.Value;
    }
    public async Task<IEnumerable<Review>> GetReviews(int prev, int perPage)
    {
        perPage = int.Min(perPage, _paginationSettings.MaxPerPage);
        query = query.Where(r => r.Id > prev).Take(perPage);
        return await query.ToListAsync();
    }

    public async Task<List<Review>> GetReviewsByDiningHallId(int diningHallId, int prev, int perPage)
    {
        var query = _dbContext.Review.AsQueryable();

        perPage = int.Min(perPage, _paginationSettings.MaxPerPage);

        query = query.Where(r => r.Id > prev && r.DiningHallId == diningHallId).Take(perPage);

        return await query.ToListAsync();
    }

    public async Task<List<Review>> GetReviewsByDormId(int dormId)
    {
        return await _dbContext.Review.Include(r => r.User).Where(r => r.DormId == dormId).ToListAsync();
    }

    public Task<List<Review>> GetReviewsByDormId(int dormId, int prev, int perPage)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Review>> GetReviewsByParkingGarageId(int parkingGarageId)
    {
        return await _dbContext.Review.Include(r => r.User).Where(r => r.ParkingGarageId == parkingGarageId).ToListAsync();
    }

    public Task<List<Review>> GetReviewsByParkingGarageId(int parkingGarageId, int prev, int perPage)
    {
        throw new NotImplementedException();
    }

    public async Task SaveReview(Review review)
    {
        await _dbContext.AddAsync(review);
        await _dbContext.SaveChangesAsync();
    }
}