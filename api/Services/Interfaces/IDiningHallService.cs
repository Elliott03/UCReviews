using api.Models;

public interface IDiningHallService
{
    Task<IEnumerable<DiningHall>> GetDiningHalls(int prev, int perPage, string? searchTerm = null);
    Task<DiningHall> GetDiningHall(string slug);
}