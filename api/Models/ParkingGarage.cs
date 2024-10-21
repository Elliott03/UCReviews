namespace api.Models;

using System.ComponentModel.DataAnnotations;

public class ParkingGarage : ReviewableEntity
{
    public string Name { get; set; }

    [Required]
    public string Slug { get; set; }

    public string NameQueryParameter { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public string Campus { get; set; }
    public string Address { get; set; }
    public bool PermitRequired { get; set; }
}