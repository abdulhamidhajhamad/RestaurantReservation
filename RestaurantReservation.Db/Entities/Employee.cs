using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Entities;

[Table("Employees")]
public class Employee
{
    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [Column("restaurant_id")]
    public int RestaurantId { get; set; }

    [Column("first_name")]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    public string LastName { get; set; } = null!;

    [Column("position")]
    public string Position { get; set; } = null!;

    public Restaurant Restaurant { get; set; } = null!;

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}