using System;
using api.Models;

namespace api.Services.Interfaces;

public interface IParkingGarageService
{
    public Task<IEnumerable<ParkingGarage>> GetParkingGarages(int prev, int perPage);
    public Task<ParkingGarage> GetParkingGarage(int id);
    public Task<ParkingGarage> GetParkingGarage(string slug);
}
