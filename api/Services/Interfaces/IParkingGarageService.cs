using System;
using api.Models;

namespace api.Services.Interfaces;

public interface IParkingGarageService
{
    public Task<IEnumerable<ParkingGarage>> GetParkingGarages();
    public Task<ParkingGarage> GetParkingGarage(int id, bool includeReviews);
    public Task<ParkingGarage> GetParkingGarage(string slug, bool includeReviews);
}
