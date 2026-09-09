namespace RestaurantReservation.Db.Entities.Views;

public class EmployeeWithRestaurantView
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Position { get; set; } = null!;


    public int RestaurantId { get; set; }

    public string RestaurantName { get; set; } = null!;

    public string RestaurantAddress { get; set; } = null!;

    public string RestaurantPhone { get; set; } = null!;
}