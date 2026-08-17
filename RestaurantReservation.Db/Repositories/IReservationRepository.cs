using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories;

public interface IReservationRepository
{
    Task CreateReservation(Reservation reservation);
    Task<List<Reservation>> GetAllReservations();
    Task<Reservation?> GetReservationById(int id);
    Task UpdateReservation(Reservation reservation);
    Task DeleteReservation(int id);
}