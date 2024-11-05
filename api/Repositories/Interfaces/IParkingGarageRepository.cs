using System;
using api.Models;

namespace api.Repositories.Interfaces;

public interface IParkingGarageRepository
{
    public Task<IEnumerable<ParkingGarage>> GetAllParkingGarages(bool includeReviews, int prev, int perPage);
    public Task<ParkingGarage> GetParkingGarage(string slug, bool includeReviews);
    public Task<ParkingGarage> GetParkingGarage(int id, bool includeReviews);
}
