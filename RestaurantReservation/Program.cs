using RestaurantReservation.Db.Context;
using RestaurantReservation.Db.Repositories;


var context = new RestaurantReservationDbContext();


var reservationRepository = new ReservationRepository(context);

var reservationDetails = await reservationRepository
    .GetReservationsWithCustomerAndRestaurant();


Console.WriteLine("Reservations With Customer And Restaurant:");

foreach (var reservation in reservationDetails)
{
    Console.WriteLine(
        $"Reservation: {reservation.ReservationId} | " +
        $"Customer: {reservation.FirstName} {reservation.LastName} | " +
        $"Restaurant: {reservation.RestaurantName}"
    );
}


var employeeRepository = new EmployeeRepository(context);

var employeesWithRestaurant =
    await employeeRepository.GetEmployeesWithRestaurant();


Console.WriteLine("Employees With Restaurant:");

foreach (var employee in employeesWithRestaurant)
{
    Console.WriteLine(
        $"Employee: {employee.FirstName} {employee.LastName} | " +
        $"Position: {employee.Position} | " +
        $"Restaurant: {employee.RestaurantName}"
    );
}