using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DL;
using Models;

namespace BL
{
    public interface ISpotBL
    {
        Task<List<Spot>> GetSpotsAsync();
        Task<Spot> AddSpotAsync(Spot newSpot);
        Task<Spot> GetSpotByIdAsync(Guid id);
        // Task<Spot> GetSpotByNumberAsync(int number);
        Task<Spot> DeleteSpotAsync(Spot spot2BDeleted);
        Task<Spot> UpdateSpotAsync(Spot spot2BUpdated);
    }
}