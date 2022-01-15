using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class ReservationRepo : IReservationRepo
    {
        private readonly DataContext _context;
        public ReservationRepo(DataContext context)
        {
            _context = context;

        }
        public async Task<Reservation> AddReservationAsync(Reservation newReservation)
        {
            await _context.Reservations.AddAsync(newReservation);
            await _context.SaveChangesAsync();
            return newReservation;
        }

        public async Task<Reservation> DeleteReservationAsync(Reservation reservation2BDeleted)
        {
            _context.Reservations.Remove(reservation2BDeleted);
            await _context.SaveChangesAsync();
            return reservation2BDeleted;
        }

        public async Task<Reservation> GetReservationByIdAsync(Guid id)
        {
            return await _context.Reservations
                .AsNoTracking()
                .FirstOrDefaultAsync(reservation => reservation.Id == id);
        }
        public async Task<List<Reservation>> GetReservationsByUserAsync(User user)
        {
            return await _context.Reservations
                .AsNoTracking()
                // .Select(reservation => reservation)
                .Where(reservation => reservation.User == user)
                .ToListAsync();
        }

        public async Task<List<Reservation>> GetReservationsBySpotAsync(Spot spot)
        {
            return await _context.Reservations
                .AsNoTracking()
                // .Select(reservation => reservation)
                .Where(reservation => reservation.Spot == spot)
                .ToListAsync();
        }

        public async Task<List<Reservation>> GetReservationsAsync()
        {
            return await _context.Reservations
                .AsNoTracking()
                .Select(reservation => reservation)
                .ToListAsync();
        }

        public async Task<Reservation> UpdateReservationAsync(Reservation reservation2BUpdated)
        {
            Reservation oldReservation = await _context.Reservations.Where(b => b.Id == reservation2BUpdated.Id).FirstOrDefaultAsync();
            _context.Entry(oldReservation).CurrentValues.SetValues(reservation2BUpdated);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return oldReservation;
        }
    }
}