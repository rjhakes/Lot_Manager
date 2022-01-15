using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DL;
using Models;
namespace BL
{
    public class ReservationBL : IReservationBL
    {
        private readonly IReservationRepo _repo;
        public ReservationBL(IReservationRepo repo)
        {
            _repo = repo;

        }
        public async Task<Reservation> AddReservationAsync(Reservation newReservation)
        {
            return await _repo.AddReservationAsync(newReservation);
        }

        public async Task<Reservation> DeleteReservationAsync(Reservation reservation2BDeleted)
        {
            return await _repo.DeleteReservationAsync(reservation2BDeleted);
        }

        public async Task<Reservation> GetReservationByIdAsync(Guid id)
        {
            return await _repo.GetReservationByIdAsync(id);
        }
        public async Task<List<Reservation>> GetReservationsByUserAsync(User user)
        {
            return await _repo.GetReservationsByUserAsync(user);
        }
        public async Task<List<Reservation>> GetReservationsBySpotAsync(Spot spot)
        {
            return await _repo.GetReservationsBySpotAsync(spot);
        }
        public async Task<List<Reservation>> GetReservationsAsync()
        {
            return await _repo.GetReservationsAsync();
        }

        public async Task<Reservation> UpdateReservationAsync(Reservation reservation2BUpdated)
        {
            return await _repo.UpdateReservationAsync(reservation2BUpdated);
        }
    }
}