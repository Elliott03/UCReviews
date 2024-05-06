using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Implementations;

public class ReviewRepository : IReviewRepository
{
    private readonly UCReviewsContext _dbContext;
    public ReviewRepository(UCReviewsContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Review>> GetAllReviews()
    {
        return await _dbContext.Review.ToListAsync();
    }
    public async Task<List<Review>> GetReviewsByBuildingId(int buildingId) 
    {
        return await _dbContext.Review.Include(r => r.User).Where(r => r.BuildingId == buildingId).ToListAsync();
    }
    public async Task SaveReview(Review review)
    {
        await _dbContext.AddAsync(review);
        await _dbContext.SaveChangesAsync();
    }
}