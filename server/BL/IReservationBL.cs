using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DL;
using Models;

namespace BL
{
    public interface IReservationBL
    {
        Task<List<Reservation>> GetReservationsAsync();
        Task<Reservation> AddReservationAsync(Reservation newReservation);
        Task<Reservation> GetReservationByIdAsync(Guid id);
        Task<List<Reservation>> GetReservationsByUserAsync(User user);
        Task<List<Reservation>> GetReservationsBySpotAsync(Spot spot);
        Task<Reservation> DeleteReservationAsync(Reservation reservation2BDeleted);
        Task<Reservation> UpdateReservationAsync(Reservation reservation2BUpdated);
    }
}