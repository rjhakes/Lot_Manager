using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DL;
using Models;
namespace BL
{
    public class LotBL : ILotBL
    {
        private readonly ILotRepo _repo;
        public LotBL(ILotRepo repo)
        {
            _repo = repo;

        }
        public async Task<Lot> AddLotAsync(Lot newLot)
        {
            return await _repo.AddLotAsync(newLot);
        }

        public async Task<Lot> DeleteLotAsync(Lot lot2BDeleted)
        {
            return await _repo.DeleteLotAsync(lot2BDeleted);
        }

        public async Task<Lot> GetLotByIdAsync(Guid id)
        {
            return await _repo.GetLotByIdAsync(id);
        }
        public async Task<Lot> GetLotByNameAsync(string name)
        {
            return await _repo.GetLotByNameAsync(name);
        }

        public async Task<List<Lot>> GetLotsAsync()
        {
            return await _repo.GetLotsAsync();
        }

        public async Task<Lot> UpdateLotAsync(Lot lot2BUpdated)
        {
            return await _repo.UpdateLotAsync(lot2BUpdated);
        }
    }
}