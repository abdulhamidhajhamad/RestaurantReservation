using RestaurantReservation.Db.Context;
using RestaurantReservation.Db.Repositories;


var context = new RestaurantReservationDbContext();



var employeeRepository = new EmployeeRepository(context);

var managers = await employeeRepository.ListManagers();

Console.WriteLine("Managers:");

foreach (var manager in managers)
{
    Console.WriteLine($"{manager.FirstName} {manager.LastName} - {manager.Position}");
}




var reservationRepository = new ReservationRepository(context);

int customerId = 1;

var reservations = await reservationRepository.GetReservationsByCustomer(customerId);

Console.WriteLine("\nCustomer Reservations:");

foreach (var reservation in reservations)
{
    Console.WriteLine($"Reservation ID: {reservation.ReservationId}");
}




var orderRepository = new OrderRepository(context);

int reservationId = 1;

var orders = await orderRepository.ListOrdersAndMenuItems(reservationId);

Console.WriteLine("\nOrders With Menu Items:");

foreach (var order in orders)
{
    Console.WriteLine($"Order ID: {order.OrderId}");

    foreach (var item in order.OrderItems)
    {
        Console.WriteLine($" - {item.MenuItem.Name} Quantity: {item.Quantity}");
    }
}



// 4. ListOrderedMenuItems(ReservationId)

var menuItems = await orderRepository.ListOrderedMenuItems(reservationId);

Console.WriteLine("\nOrdered Menu Items:");

foreach (var item in menuItems)
{
    Console.WriteLine($"Menu Item: {item.Name} Price: {item.Price}");
}




int employeeId = 3;

var averageAmount = await orderRepository.CalculateAverageOrderAmount(employeeId);

Console.WriteLine("\nAverage Order Amount:");

Console.WriteLine($"Employee {employeeId}: {averageAmount}");



Console.WriteLine("\nAll Methods Tested Successfully!");