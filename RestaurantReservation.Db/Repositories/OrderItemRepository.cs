using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Context;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories;

public class OrderItemRepository
{
    private readonly RestaurantReservationDbContext _context;

    public OrderItemRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }


    public async Task CreateOrderItem(OrderItem orderItem)
    {
        await _context.OrderItems.AddAsync(orderItem);
        await _context.SaveChangesAsync();
    }


    public async Task<List<OrderItem>> GetAllOrderItems()
    {
        return await _context.OrderItems
            .ToListAsync();
    }


    public async Task<OrderItem?> GetOrderItemById(int orderItemId)
    {
        return await _context.OrderItems
            .FirstOrDefaultAsync(o => o.OrderItemId == orderItemId);
    }


    public async Task UpdateOrderItem(OrderItem orderItem)
    {
        _context.OrderItems.Update(orderItem);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteOrderItem(int orderItemId)
    {
        var orderItem = await GetOrderItemById(orderItemId);

        if (orderItem == null)
            return;

        _context.OrderItems.Remove(orderItem);
        await _context.SaveChangesAsync();
    }
}