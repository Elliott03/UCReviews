using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Enums;

namespace api.Models;
public class Vote 
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public int ReviewId { get; set; }
    public Review Review { get; set; }
    public VoteType? SelectedVote { get; set; }


}