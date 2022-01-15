using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class SpotRepo : ISpotRepo
    {
        private readonly DataContext _context;
        public SpotRepo(DataContext context)
        {
            _context = context;

        }
        public async Task<Spot> AddSpotAsync(Spot newSpot)
        {
            await _context.Spots.AddAsync(newSpot);
            await _context.SaveChangesAsync();
            return newSpot;
        }

        public async Task<Spot> DeleteSpotAsync(Spot spot2BDeleted)
        {
            _context.Spots.Remove(spot2BDeleted);
            await _context.SaveChangesAsync();
            return spot2BDeleted;
        }

        public async Task<Spot> GetSpotByIdAsync(Guid id)
        {
            return await _context.Spots
                .AsNoTracking()
                .FirstOrDefaultAsync(spot => spot.Id == id);
        }
        // public async Task<Spot> GetSpotByNumberAsync(int number, Lot lot)
        // {
        //     return await _context.Spots
        //         .AsNoTracking()
        //         .FirstOrDefaultAsync(spot => spot.Number == number && spot.Lot == lot);
        // }

        public async Task<List<Spot>> GetSpotsAsync()
        {
            return await _context.Spots
                .AsNoTracking()
                .Select(spot => spot)
                .ToListAsync();
        }

        public async Task<Spot> UpdateSpotAsync(Spot spot2BUpdated)
        {
            Spot oldSpot = await _context.Spots.Where(b => b.Id == spot2BUpdated.Id).FirstOrDefaultAsync();
            _context.Entry(oldSpot).CurrentValues.SetValues(spot2BUpdated);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return oldSpot;
        }
    }
}