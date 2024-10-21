namespace api.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable

public class Review
{
    [Key]
    public int Id { get; set; }
    public required string ReviewText { get; set; }
    public decimal StarRating { get; set; }
    public DateTime TimeCreated { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }
    public User User { get; set; }

    [ForeignKey("Dorm")]
    public int? DormId { get; set; }
    public Dorm? Dorm { get; set; }

    [ForeignKey("ParkingGarage")]
    public int? ParkingGarageId { get; set; }
    public ParkingGarage? ParkingGarage { get; set; }
}
