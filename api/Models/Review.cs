namespace api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Review 
{
    [Key]
    public int Id { get; set; }
    public string ReviewText { get; set; }

    public decimal StarRating { get; set; }

    public DateTime TimeCreated { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    [ForeignKey("Dorm")]
    public int? DormId { get; set; }
    [ForeignKey("ParkingGarage")]
    public int? ParkingGarageId { get; set; }
    [ForeignKey("DiningHall")]
    public int? DiningHallId { get; set; }

    public User User { get; set; }
    public Dorm? Dorm { get; set; }
    public ParkingGarage? ParkingGarage { get; set; }
    public DiningHall? DiningHall { get; set; }

    
}