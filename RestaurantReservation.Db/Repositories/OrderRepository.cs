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

    public async Task<List<Order>> ListOrdersAndMenuItems(int reservationId)
    {
        return await _context.Orders.Where(o => o.ReservationId == reservationId)
            .Include(OrderItem => OrderItem.OrderItems)
            .ThenInclude(MenuItem=> MenuItem.MenuItem).ToListAsync();
    }
    public async Task<List<MenuItem>> ListOrderedMenuItems(int ReservationId)
    {
        return await _context.Orders.Where(e => e.ReservationId == ReservationId)
            .SelectMany(order => order.OrderItems).Select(menuItem => menuItem.MenuItem).ToListAsync();
        
    }

    public async Task<decimal> CalculateAverageOrderAmount(int EmployeeId)
    {
        return await _context.Orders
            .Where(o => o.EmployeeId == EmployeeId)
            .AverageAsync(o => o.TotalAmount);
    }
}