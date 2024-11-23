using System;
using api.Models;

namespace api.Repositories.Interfaces;

public interface IParkingGarageRepository
{
    public Task<IEnumerable<ParkingGarage>> GetParkingGarages(int prev, int perPage);
    public Task<ParkingGarage> GetParkingGarage(string slug);
    public Task<ParkingGarage> GetParkingGarage(int id);
}
