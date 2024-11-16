public interface IDiningHallRepository
{
    public Task<IEnumerable<DiningHall>> GetDiningHalls(int prev, int perPage);
    public Task<DiningHall> GetDiningHall(string queryParam);
}