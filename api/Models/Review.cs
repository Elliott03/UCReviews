namespace api.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable enable

public class Review
{
    [Key]
    public int Id { get; set; }
    public required string ReviewText { get; set; }

    [Precision(2, 1)]
    public decimal StarRating { get; set; }
    public DateTime TimeCreated { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }
    public virtual User User { get; set; }

    [ForeignKey("Dorm")]
    public int? DormId { get; set; }
    public virtual Dorm? Dorm { get; set; }

    [ForeignKey("ParkingGarage")]
    public int? ParkingGarageId { get; set; }
    public virtual ParkingGarage? ParkingGarage { get; set; }

    [ForeignKey("DiningHall")]
    public int? DiningHallId { get; set; }
    public virtual DiningHall? DiningHall { get; set; }
}
