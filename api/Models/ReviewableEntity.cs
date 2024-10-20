using System.ComponentModel.DataAnnotations;

namespace api.Models;

public abstract class ReviewableEntity
{
    [Key]
    public int Id { get; set; }
    public List<Review> Reviews { get; set; } = new List<Review>();
}