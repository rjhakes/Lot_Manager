using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DL;
using Models;
namespace BL
{
    public class SpotBL : ISpotBL
    {
        private readonly ISpotRepo _repo;
        public SpotBL(ISpotRepo repo)
        {
            _repo = repo;

        }
        public async Task<Spot> AddSpotAsync(Spot newSpot)
        {
            return await _repo.AddSpotAsync(newSpot);
        }

        public async Task<Spot> DeleteSpotAsync(Spot spot2BDeleted)
        {
            return await _repo.DeleteSpotAsync(spot2BDeleted);
        }

        public async Task<Spot> GetSpotByIdAsync(Guid id)
        {
            return await _repo.GetSpotByIdAsync(id);
        }
        // public async Task<Spot> GetSpotByNumberAsync(int number)
        // {
        //     return await _repo.GetSpotByNumberAsync(number);
        // }

        public async Task<List<Spot>> GetSpotsAsync()
        {
            return await _repo.GetSpotsAsync();
        }

        public async Task<Spot> UpdateSpotAsync(Spot spot2BUpdated)
        {
            return await _repo.UpdateSpotAsync(spot2BUpdated);
        }
    }
}