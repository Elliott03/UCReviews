namespace api.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
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

    [JsonIgnore]
    public virtual User User { get; set; }

    [ForeignKey("Dorm")]
    public int? DormId { get; set; }

    [JsonIgnore]
    public virtual Dorm? Dorm { get; set; }

    [ForeignKey("ParkingGarage")]
    public int? ParkingGarageId { get; set; }

    [JsonIgnore]
    public virtual ParkingGarage? ParkingGarage { get; set; }

    [ForeignKey("DiningHall")]
    public int? DiningHallId { get; set; }

    [JsonIgnore]
    public virtual DiningHall? DiningHall { get; set; }

    [ForeignKey("Course")]
    public int? CourseId { get; set; }

    [JsonIgnore]
    public virtual Course? Course { get; set; }
}
