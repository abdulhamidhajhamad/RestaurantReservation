using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Context;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Entities.Views;

namespace RestaurantReservation.Db.Repositories;

public class EmployeeRepository:IEmployeeRepository
{
    private readonly RestaurantReservationDbContext _context;

    public EmployeeRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }


    public async Task CreateEmployee(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
    }


    public async Task<List<Employee>> GetAllEmployees()
    {
        return await _context.Employees
            .ToListAsync();
    }


    public async Task<Employee?> GetEmployeeById(int employeeId)
    {
        return await _context.Employees
            .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
    }


    public async Task UpdateEmployee(Employee employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteEmployee(int employeeId)
    {
        var employee = await GetEmployeeById(employeeId);

        if (employee == null)
            return;

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Employee>> ListManagers()
    {
        return await _context.Employees.Where(e => e.Position == "Manager").ToListAsync();
    }
    public async Task<List<EmployeeWithRestaurantView>> GetEmployeesWithRestaurant()
    {
        return await _context.EmployeeWithRestaurantViews
            .ToListAsync();
    }
    public async Task<Employee?> GetByNameAsync(string name)
    {
        return await _context.Employees
            .FirstOrDefaultAsync(e => e.FirstName == name || e.LastName == name);
    }
}