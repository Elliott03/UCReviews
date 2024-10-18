public interface IDiningHallRepository
{
    public Task<IEnumerable<DiningHall>> GetAllDiningHalls();
    public Task<DiningHall> GetDiningHall(string queryParam);
}