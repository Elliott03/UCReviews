using System;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Implementations;

public class ParkingGarageRepository : IParkingGarageRepository
{
    private readonly UCReviewsContext _dbContext;

    public ParkingGarageRepository(UCReviewsContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ParkingGarage>> GetAllParkingGarages()
    {
        return await _dbContext.ParkingGarage.ToListAsync();
    }

    public async Task<ParkingGarage> GetParkingGarage(string slug)
    {
        return await _dbContext.ParkingGarage.Where(g => g.Slug == slug).FirstAsync();
    }

    public async Task<ParkingGarage> GetParkingGarageById(int id)
    {
        return await _dbContext.ParkingGarage.Where(g => g.Id == id).FirstAsync();
    }
}
