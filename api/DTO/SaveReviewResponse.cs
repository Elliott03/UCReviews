namespace api.Dto;

using api.Models;

public class SaveReviewResponse
{
    public Review Review { get; set; }

#nullable enable
    public IReviewable? Reviewable { get; set; }

    public decimal? AverageRating { get; set; }
}