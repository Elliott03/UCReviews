namespace api.Dto;

using api.Models;

public class ReviewWithUser
{
    public Review review { get; set; }
    public ReviewUser user { get; set; }
}