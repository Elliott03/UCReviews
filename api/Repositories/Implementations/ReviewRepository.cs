namespace api.Repositories.Implementations;

using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
    public async Task<List<Review>> GetReviewsByDormId(int dormId)
    {
        return await _dbContext.Review.Include(r => r.User).Where(r => r.DormId == dormId).ToListAsync();
    }

    public async Task<List<Review>> GetReviewsByParkingGarageId(int parkinGarageId)
    {
        return await _dbContext.Review.Include(r => r.User).Where(r => r.ParkingGarageId == parkinGarageId).ToListAsync();
    }

    public async Task SaveReview(Review review)
    {
        await _dbContext.AddAsync(review);
        await _dbContext.SaveChangesAsync();
    }
}