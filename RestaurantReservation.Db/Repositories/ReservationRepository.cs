using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Context;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Entities.Views;

namespace RestaurantReservation.Db.Repositories;

public class ReservationRepository:IReservationRepository
{
    private readonly RestaurantReservationDbContext _context;

    public ReservationRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }


    public async Task CreateReservation(Reservation reservation)
    {
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();
    }


    public async Task<List<Reservation>> GetAllReservations()
    {
        return await _context.Reservations
            .ToListAsync();
    }


    public async Task<Reservation?> GetReservationById(int reservationId)
    {
        return await _context.Reservations
            .FirstOrDefaultAsync(r => r.ReservationId == reservationId);
    }


    public async Task UpdateReservation(Reservation reservation)
    {
        _context.Reservations.Update(reservation);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteReservation(int reservationId)
    {
        var reservation = await GetReservationById(reservationId);

        if (reservation == null)
            return;

        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();
    }
    public async Task<List<Reservation>> GetReservationsByCustomer(int id)
    {
        return await _context.Reservations.Where(e => e.CustomerId == id).ToListAsync();
    }
    public async Task<List<ReservationWithCustomerRestaurantView>> 
        GetReservationsWithCustomerAndRestaurant()
    {
        return await _context.ReservationWithCustomerRestaurantViews
            .ToListAsync();
    }
}