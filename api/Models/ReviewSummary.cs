using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

public class ReviewSummary
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Dorm")]
    public int? DormId { get; set; }

    [ForeignKey("ParkingGarage")]
    public int? ParkingGarageId { get; set; }

    [ForeignKey("DiningHall")]
    public int? DiningHallId { get; set; }

    [Precision(10, 9)]
    public decimal AverageRating { get; set; }
    public int TotalReviews { get; set; } // For computing a running average: curAvg = curAvg + (newRating - curAvg) / totalReviews
    public string SummaryText { get; set; } // For displaying an AI-generated summary of the reviews

#nullable enable
    [JsonIgnore]
    public virtual Dorm? Dorm { get; set; }
    [JsonIgnore]
    public virtual ParkingGarage? ParkingGarage { get; set; }
    [JsonIgnore]
    public virtual DiningHall? DiningHall { get; set; }
}
