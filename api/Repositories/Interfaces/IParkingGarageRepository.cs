using System;
using api.Models;

namespace api.Repositories.Interfaces;

public interface IParkingGarageRepository
{
    public Task<IEnumerable<ParkingGarage>> GetAllParkingGarages();
    public Task<ParkingGarage> GetParkingGarage(string slug);
    public Task<ParkingGarage> GetParkingGarageById(int id);
}
