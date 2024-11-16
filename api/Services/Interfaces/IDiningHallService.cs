public interface IDiningHallService
{
    public Task<IEnumerable<DiningHall>> GetDiningHalls(int prev, int perPage);
    public Task<DiningHall> GetDiningHall(string slug);
}