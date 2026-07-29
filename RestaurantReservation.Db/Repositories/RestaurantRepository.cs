using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Context;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories;

public class RestaurantRepository
{
    private readonly RestaurantReservationDbContext _context;

    public RestaurantRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }


    public async Task CreateRestaurant(Restaurant restaurant)
    {
        await _context.Restaurants.AddAsync(restaurant);
        await _context.SaveChangesAsync();
    }


    public async Task<List<Restaurant>> GetAllRestaurants()
    {
        return await _context.Restaurants
            .ToListAsync();
    }


    public async Task<Restaurant?> GetRestaurantById(int restaurantId)
    {
        return await _context.Restaurants
            .FirstOrDefaultAsync(r => r.RestaurantId == restaurantId);
    }


    public async Task UpdateRestaurant(Restaurant restaurant)
    {
        _context.Restaurants.Update(restaurant);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteRestaurant(int restaurantId)
    {
        var restaurant = await GetRestaurantById(restaurantId);

        if (restaurant == null)
            return;

        _context.Restaurants.Remove(restaurant);
        await _context.SaveChangesAsync();
    }
    
    public async Task<decimal> CalculateRestaurantRevenue(int restaurantId)
    {
        return await _context.Restaurants
            .Where(r => r.RestaurantId == restaurantId)
            .Select(r => _context.CalculateRestaurantRevenue(r.RestaurantId))
            .FirstAsync();
    }
}