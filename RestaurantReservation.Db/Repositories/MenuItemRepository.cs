using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Context;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories;

public class MenuItemRepository
{
    private readonly RestaurantReservationDbContext _context;

    public MenuItemRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }


    public async Task CreateMenuItem(MenuItem menuItem)
    {
        await _context.MenuItems.AddAsync(menuItem);
        await _context.SaveChangesAsync();
    }


    public async Task<List<MenuItem>> GetAllMenuItems()
    {
        return await _context.MenuItems
            .ToListAsync();
    }


    public async Task<MenuItem?> GetMenuItemById(int itemId)
    {
        return await _context.MenuItems
            .FirstOrDefaultAsync(m => m.ItemId == itemId);
    }


    public async Task UpdateMenuItem(MenuItem menuItem)
    {
        _context.MenuItems.Update(menuItem);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteMenuItem(int itemId)
    {
        var menuItem = await GetMenuItemById(itemId);

        if (menuItem == null)
            return;

        _context.MenuItems.Remove(menuItem);
        await _context.SaveChangesAsync();
    }


}