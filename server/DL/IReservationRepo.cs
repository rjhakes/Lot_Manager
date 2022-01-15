using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public interface IReservationRepo
    {
        Task<Reservation> AddReservationAsync(Reservation newReservation);
        Task<Reservation> DeleteReservationAsync(Reservation reservation2BDeleted);
        Task<Reservation> GetReservationByIdAsync(Guid id);
        Task<List<Reservation>> GetReservationsByUserAsync(User user);
        Task<List<Reservation>> GetReservationsBySpotAsync(Spot spot);
        Task<List<Reservation>> GetReservationsAsync();
        Task<Reservation> UpdateReservationAsync(Reservation reservation2BUpdated);
    }
}