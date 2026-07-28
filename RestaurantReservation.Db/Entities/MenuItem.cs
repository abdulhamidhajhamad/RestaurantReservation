using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Entities;

[Table("MenuItems")]
public class MenuItem
{
    [Key]
    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("restaurant_id")]
    public int RestaurantId { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("description")]
    public string Description { get; set; } = null!;

    [Column("price")]
    public decimal Price { get; set; }

    public Restaurant Restaurant { get; set; } = null!;

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}