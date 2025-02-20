namespace api.Extensions;

using api.Models;

public static class ReviewExtensions
{
#nullable enable
    public static async Task<IReviewable?> GetReviewableAsync(this Review review, UCReviewsContext dbContext)
    {
        if (review.DiningHallId != null)
            return await dbContext.Set<DiningHall>().FindAsync(review.DiningHallId);

        if (review.ParkingGarageId != null)
            return await dbContext.Set<ParkingGarage>().FindAsync(review.ParkingGarageId);

        if (review.DormId != null)
            return await dbContext.Set<Dorm>().FindAsync(review.DormId);

        if (review.CourseId != null)
            return await dbContext.Set<Course>().FindAsync(review.CourseId);

        return null;
    }
}
