namespace api.Dto;

using System.ComponentModel.DataAnnotations;

public class ReviewUser
{
    [Key]
    public int Id { get; set; }

    public string Email { get; set; }

    public string UserName { get => Email.Split('@')[0]; }
}