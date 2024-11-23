namespace api.Models;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Dorm : IReviewable
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
    public string Style { get; set; }
    public string Cost { get; set; }
    public string Description { get; set; }
    public string NameQueryParameter { get; set; }

    [JsonIgnore]
    public virtual List<Review> Reviews { get; set; } = [];
    public virtual ReviewSummary ReviewSummary { get; set; }

}