using System.ComponentModel.DataAnnotations;
using api.Models;
public class ParkingGarage
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string NameQueryParameter { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public string Campus { get; set; }
    public string Address { get; set; }
    public bool PermitRequired { get; set; }
    public List<Review> Reviews { get; set; }
}