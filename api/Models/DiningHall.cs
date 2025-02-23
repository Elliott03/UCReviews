using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.Models;

public class DiningHall : IReviewable
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Location { get; set; }
    public string IncludedInMealPlan { get; set; }
    public string NameQueryParameter { get; set; }
    [JsonIgnore]
    public virtual List<Review> Reviews { get; set; } = [];
    public virtual ReviewSummary ReviewSummary { get; set; }
}