namespace api.Dto;

using api.Models;

public class ReviewWithSummary
{
    public Review review { get; set; }
    public ReviewSummary summary { get; set; }
}