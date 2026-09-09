using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Entities;

[Table("Restaurants")]
public class Restaurant
{
    [Column("restaurant_id")]
    public int RestaurantId { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("address")]
    public string Address { get; set; } = null!;

    [Column("phone_number")]
    public string PhoneNumber { get; set; } = null!;

    [Column("opening_hours")]
    public string OpeningHours { get; set; } = null!;

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public ICollection<Table> Tables { get; set; } = new List<Table>();

    public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}