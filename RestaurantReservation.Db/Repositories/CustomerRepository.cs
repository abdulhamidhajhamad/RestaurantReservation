using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Context;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Models;
using Microsoft.EntityFrameworkCore;
namespace RestaurantReservation.Db.Repositories;

public class CustomerRepository
{
    private readonly RestaurantReservationDbContext _context;

    public CustomerRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }


    public async Task CreateCustomer(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }


    public async Task<List<Customer>> GetAllCustomers()
    {
        return await _context.Customers
            .ToListAsync();
    }


    public async Task<Customer?> GetCustomerById(int customerId)
    {
        return await _context.Customers
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);
    }


    public async Task UpdateCustomer(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteCustomer(int customerId)
    {
        var customer = await GetCustomerById(customerId);

        if (customer == null)
            return;

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }
    public async Task<List<CustomerReservationResult>> GetCustomersByPartySize(int minPartySize)
    {
        return await _context.CustomerReservationResults
            .FromSqlInterpolated(
                $"EXEC dbo.GetCustomersByPartySize {minPartySize}"
            )
            .ToListAsync();
    }
}