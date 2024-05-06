namespace api.Models;

using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime TimeCreated { get; set; }
    public byte[] Salt { get; set; }
    public List<Review> Reviews { get; set; }
}