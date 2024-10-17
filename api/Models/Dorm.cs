namespace api.Models;

using System.ComponentModel.DataAnnotations;

public class Dorm
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Style { get; set; }
    public string Cost { get; set; }
    public string Description { get; set; }
    public string NameQueryParameter { get; set; }
    public List<Review> Reviews { get; set; }

}