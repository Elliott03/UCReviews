using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    public virtual Dorm? Dorm { get; set; }
    public virtual ParkingGarage? ParkingGarage { get; set; }
    public virtual DiningHall? DiningHall { get; set; }
}
