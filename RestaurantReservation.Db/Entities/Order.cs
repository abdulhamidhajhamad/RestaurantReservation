using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Entities;

[Table("Orders")]
public class Order
{
    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("reservation_id")]
    public int ReservationId { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [Column("order_date")]
    public DateTime OrderDate { get; set; }

    [Column("total_amount")]
    public decimal TotalAmount { get; set; }

    public Reservation Reservation { get; set; } = null!;

    public Employee Employee { get; set; } = null!;

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}