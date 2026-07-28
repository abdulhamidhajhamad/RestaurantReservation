using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Context;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories;

public class OrderRepository
{
    private readonly RestaurantReservationDbContext _context;

    public OrderRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }


    public async Task CreateOrder(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }


    public async Task<List<Order>> GetAllOrders()
    {
        return await _context.Orders
            .ToListAsync();
    }


    public async Task<Order?> GetOrderById(int orderId)
    {
        return await _context.Orders
            .FirstOrDefaultAsync(o => o.OrderId == orderId);
    }


    public async Task UpdateOrder(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteOrder(int orderId)
    {
        var order = await GetOrderById(orderId);

        if (order == null)
            return;

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }
}