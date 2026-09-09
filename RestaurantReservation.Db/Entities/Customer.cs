using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Entities;

[Table("Customers")]
public class Customer
{
    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Column("first_name")]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    public string LastName { get; set; } = null!;

    [Column("email")]
    public string Email { get; set; } = null!;

    [Column("phone_number")]
    public string PhoneNumber { get; set; } = null!;

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}