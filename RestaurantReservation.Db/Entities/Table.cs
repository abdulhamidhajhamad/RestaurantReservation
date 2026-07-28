using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Entities;

[Table("Tables")]
public class Table
{
    [Column("table_id")]
    public int TableId { get; set; }

    [Column("restaurant_id")]
    public int RestaurantId { get; set; }

    [Column("capacity")]
    public int Capacity { get; set; }

    public Restaurant Restaurant { get; set; } = null!;

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}