using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Entities.Views;
using RestaurantReservation.Db.Seeds;
using RestaurantReservation.Db.Entities.Views;
namespace RestaurantReservation.Db.Context;

public class RestaurantReservationDbContext : DbContext
{
    public RestaurantReservationDbContext()
    {
        
    }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Table> Tables { get; set; }
    public DbSet<ReservationWithCustomerRestaurantView> ReservationWithCustomerRestaurantViews { get; set; }
    public DbSet<EmployeeWithRestaurantView> EmployeeWithRestaurantViews { get; set; }
    public decimal CalculateRestaurantRevenue(int restaurantId)
        => throw new NotImplementedException();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=ABDULHAMID-HAJH;Database=RestaurantReservationCore;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Reservation>().HasOne(e=>e.Customer).WithMany(r=>r.Reservations).HasForeignKey(e=>e.CustomerId);
        modelBuilder.Entity<Reservation>().HasOne(e=>e.Restaurant).WithMany(r=>r.Reservations).HasForeignKey(e=>e.RestaurantId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Reservation>().HasOne(e=>e.Table).WithMany(r=>r.Reservations).HasForeignKey(e=>e.TableId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Employee>().HasOne(e=>e.Restaurant).WithMany(r=>r.Employees).HasForeignKey(e=>e.RestaurantId);
        modelBuilder.Entity<MenuItem>().HasOne(e=>e.Restaurant).WithMany(r=>r.MenuItems).HasForeignKey(e=>e.RestaurantId);
        modelBuilder.Entity<Order>().HasOne(e=>e.Employee).WithMany(r=>r.Orders).HasForeignKey(e=>e.EmployeeId);
        modelBuilder.Entity<Order>().HasOne(e=>e.Reservation).WithMany(r=>r.Orders).HasForeignKey(e=>e.ReservationId);
        modelBuilder.Entity<OrderItem>().HasOne(e=>e.Order).WithMany(r=>r.OrderItems).HasForeignKey(e=>e.OrderId);
        
        modelBuilder.Entity<OrderItem>().HasOne(e=>e.MenuItem).WithMany(r=>r.OrderItems).HasForeignKey(e=>e.ItemId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<ReservationWithCustomerRestaurantView>()
            .HasNoKey()
            .ToView("vw_ReservationsWithCustomerAndRestaurant");
        modelBuilder.Entity<EmployeeWithRestaurantView>()
            .HasNoKey()
            .ToView("vw_EmployeesWithRestaurant");
        modelBuilder.HasDbFunction(
                typeof(RestaurantReservationDbContext)
                    .GetMethod(nameof(CalculateRestaurantRevenue),
                        new[] { typeof(int) })!
            )
            .HasName("CalculateRestaurantRevenue");
        
        RestaurantSeed.Seed(modelBuilder);
        CustomerSeed.Seed(modelBuilder);
        TableSeed.Seed(modelBuilder);
        EmployeeSeed.Seed(modelBuilder);
        MenuItemSeed.Seed(modelBuilder);
        ReservationSeed.Seed(modelBuilder);
        OrderSeed.Seed(modelBuilder);
        OrderItemSeed.Seed(modelBuilder);
        
    }
}