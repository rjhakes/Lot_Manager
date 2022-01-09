using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DL;
using Models;

namespace BL
{
    public interface ILotBL
    {
        Task<List<Lot>> GetLotsAsync();
        Task<Lot> AddLotAsync(Lot newLot);
        Task<Lot> GetLotByIdAsync(Guid id);
        Task<Lot> GetLotByNameAsync(string name);
        Task<Lot> DeleteLotAsync(Lot lot2BDeleted);
        Task<Lot> UpdateLotAsync(Lot lot2BUpdated);
    }
}