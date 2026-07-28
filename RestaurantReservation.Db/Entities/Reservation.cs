using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Entities;

[Table("Reservations")]
public class Reservation
{
    [Column("reservation_id")]
    public int ReservationId { get; set; }

    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Column("restaurant_id")]
    public int RestaurantId { get; set; }

    [Column("table_id")]
    public int TableId { get; set; }

    [Column("reservation_date")]
    public DateTime ReservationDate { get; set; }

    [Column("party_size")]
    public int PartySize { get; set; }

    public Customer Customer { get; set; } = null!;

    public Restaurant Restaurant { get; set; } = null!;

    public Table Table { get; set; } = null!;

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}