using api.Models;

namespace api.Dto;
public class UserDto
{
    
    public int Id { get; set; }
    public string Email { get; set; }
    public DateTime TimeCreated { get; set; }
    public List<Review> Reviews { get; set; }
}