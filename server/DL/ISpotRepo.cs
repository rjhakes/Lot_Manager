using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public interface ISpotRepo
    {
        Task<Spot> AddSpotAsync(Spot newSpot);
        Task<Spot> DeleteSpotAsync(Spot spot2BDeleted);
        Task<Spot> GetSpotByIdAsync(Guid id);
        // Task<Spot> GetSpotByNumberAsync(int number, Lot lot);
        Task<List<Spot>> GetSpotsAsync();
        Task<Spot> UpdateSpotAsync(Spot spot2BUpdated);
    }
}