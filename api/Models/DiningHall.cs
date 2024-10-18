using api.Models;

public class DiningHall
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Location { get; set; }
    public string IncludedInMealPlan { get; set; }
    public string NameQueryParameter { get; set; }
    public List<Review> Reviews { get; set; }
}