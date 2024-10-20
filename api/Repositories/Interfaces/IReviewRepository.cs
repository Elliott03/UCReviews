namespace api.Repositories.Interfaces;

using api.Models;

public interface IReviewRepository
{
    public Task<IEnumerable<Review>> GetAllReviews();
    public Task<List<Review>> GetReviewsByDormId(int dormId);
    public Task<List<Review>> GetReviewsByParkingGarageId(int parkinGarageId);
    public Task SaveReview(Review review);
}