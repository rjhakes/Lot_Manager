using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class LotRepo : ILotRepo
    {
        private readonly DataContext _context;
        public LotRepo(DataContext context)
        {
            _context = context;

        }
        public async Task<Lot> AddLotAsync(Lot newLot)
        {
            await _context.Lots.AddAsync(newLot);
            await _context.SaveChangesAsync();
            return newLot;
        }

        public async Task<Lot> DeleteLotAsync(Lot lot2BDeleted)
        {
            _context.Lots.Remove(lot2BDeleted);
            await _context.SaveChangesAsync();
            return lot2BDeleted;
        }

        public async Task<Lot> GetLotByIdAsync(Guid id)
        {
            return await _context.Lots
                .AsNoTracking()
                .FirstOrDefaultAsync(lot => lot.Id == id);
        }
        public async Task<Lot> GetLotByNameAsync(string name)
        {
            return await _context.Lots
                .AsNoTracking()
                .FirstOrDefaultAsync(lot => lot.LotName == name);
        }

        public async Task<List<Lot>> GetLotsAsync()
        {
            return await _context.Lots
                .AsNoTracking()
                .Select(lot => lot)
                .ToListAsync();
        }

        public async Task<Lot> UpdateLotAsync(Lot lot2BUpdated)
        {
            Lot oldLot = await _context.Lots.Where(b => b.Id == lot2BUpdated.Id).FirstOrDefaultAsync();
            _context.Entry(oldLot).CurrentValues.SetValues(lot2BUpdated);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return oldLot;
        }
    }
}