using System;
using api.Models;

namespace api.Services.Interfaces;

public interface IParkingGarageService
{
    public Task<IEnumerable<ParkingGarage>> GetParkingGarages();
    public Task<ParkingGarage> GetParkingGarageById(int id);
    public Task<ParkingGarage> GetParkingGarage(string slug);
}
