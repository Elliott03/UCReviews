namespace api.ViewModels;
    
public class SaveReviewViewModel {
    public string ReviewText { get; set; }
    public decimal Rating { get; set; }
    public int UserId { get; set; }
    public int DormId { get; set; }
}