using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Entities;

[Table("OrderItems")]
public class OrderItem
{
    [Column("order_item_id")]
    public int OrderItemId { get; set; }

    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    public Order Order { get; set; } = null!;

    public MenuItem MenuItem { get; set; } = null!;
}