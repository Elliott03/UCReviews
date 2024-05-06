

using Microsoft.AspNetCore.Mvc;

public class SmallBuildingDto 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Style { get; set; }
    public string Cost { get; set; }
    public string Smallimage { get; set; }
    public string NameQueryParameter { get; set; }
    public double AverageRating { get; set; }
    public IActionResult Image { get; set; }
}