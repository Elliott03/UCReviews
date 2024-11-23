namespace api.Models;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class ParkingGarage : IReviewable
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Slug { get; set; }

    [Required]
    public double Latitude { get; set; }
    [Required]
    public double Longitude { get; set; }

    public string Campus { get; set; }

    [Required]
    public string Address { get; set; }
    public bool PermitRequired { get; set; }

    [JsonIgnore]
    public virtual List<Review> Reviews { get; set; } = [];

    public virtual ReviewSummary ReviewSummary { get; set; }
}