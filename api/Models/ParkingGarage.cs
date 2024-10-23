namespace api.Models;

using System.ComponentModel.DataAnnotations;

public class ParkingGarage : ReviewableEntity
{
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
}