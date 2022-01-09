using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public interface ILotRepo
    {
        Task<Lot> AddLotAsync(Lot newLot);
        Task<Lot> DeleteLotAsync(Lot lot2BDeleted);
        Task<Lot> GetLotByIdAsync(Guid id);
        Task<Lot> GetLotByNameAsync(string name);
        Task<List<Lot>> GetLotsAsync();
        Task<Lot> UpdateLotAsync(Lot lot2BUpdated);
    }
}