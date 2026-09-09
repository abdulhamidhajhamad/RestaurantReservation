using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Context;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories;

public class TableRepository
{
    private readonly RestaurantReservationDbContext _context;

    public TableRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }


    public async Task CreateTable(Table table)
    {
        await _context.Tables.AddAsync(table);
        await _context.SaveChangesAsync();
    }


    public async Task<List<Table>> GetAllTables()
    {
        return await _context.Tables
            .ToListAsync();
    }


    public async Task<Table?> GetTableById(int tableId)
    {
        return await _context.Tables
            .FirstOrDefaultAsync(t => t.TableId == tableId);
    }


    public async Task UpdateTable(Table table)
    {
        _context.Tables.Update(table);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteTable(int tableId)
    {
        var table = await GetTableById(tableId);

        if (table == null)
            return;

        _context.Tables.Remove(table);
        await _context.SaveChangesAsync();
    }
}