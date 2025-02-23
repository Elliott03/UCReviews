using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.Models;
public class Course : IReviewable
{
    [Key]
    public int Id { get; set; }
    public string Subject { get; set; }
    public string Number { get; set; }
    public string Name { get; set; }
    [Required]
    public string NameQueryParameter { get; set; }
    [JsonIgnore]
    public virtual List<Review> Reviews { get; set; } = [];
    public virtual ReviewSummary ReviewSummary { get; set; }
}