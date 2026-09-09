using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories; 
public interface IEmployeeRepository
{
    Task<Employee?> GetByNameAsync(string name);
}