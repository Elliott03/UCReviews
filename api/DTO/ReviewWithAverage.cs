namespace api.Dto;

using api.Models;

public class ReviewWithSummary
{
    public Review Review { get; set; }
    public ReviewSummary ReviewSummary { get; set; }
    public IReviewable Reviewable { get; set; }
}