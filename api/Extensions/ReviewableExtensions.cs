namespace api.Extensions;

using api.Models;
using Microsoft.EntityFrameworkCore;

public static class ReviewableExtensions
{
#nullable enable

    public static async Task<decimal?> CalculateAverageRatingAsync(this IReviewable reviewable, UCReviewsContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(reviewable);
        ArgumentNullException.ThrowIfNull(dbContext);

        // Determine the type of the reviewable and query the reviews table
        if (reviewable is DiningHall diningHall)
        {
            return await dbContext.Review
                .Where(r => r.DiningHallId == diningHall.Id)
                .AverageAsync(r => (decimal?)r.StarRating);
        }

        if (reviewable is ParkingGarage parkingGarage)
        {
            return await dbContext.Review
                .Where(r => r.ParkingGarageId == parkingGarage.Id)
                .AverageAsync(r => (decimal?)r.StarRating);
        }

        if (reviewable is Dorm dorm)
        {
            return await dbContext.Review
                .Where(r => r.DormId == dorm.Id)
                .AverageAsync(r => (decimal?)r.StarRating);
        }

        return null;
    }
}
