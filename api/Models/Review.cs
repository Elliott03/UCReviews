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
    [ForeignKey("Building")]
    public int BuildingId { get; set; }

    public User User { get; set; }
    public Building Building { get; set; }
    
}