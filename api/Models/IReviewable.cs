namespace api.Models;

public interface IReviewable
{
    public int Id { get; set; }
    public List<Review> Reviews { get; set; }
    public ReviewSummary ReviewSummary { get; set; }
}