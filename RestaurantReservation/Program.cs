using RestaurantReservation.Db.Context;
using RestaurantReservation.Db.Repositories;


var context = new RestaurantReservationDbContext();

var customerRepository = new CustomerRepository(context);

var customers = await customerRepository.GetCustomersByPartySize(3);


Console.WriteLine("Customers:");

foreach (var customer in customers)
{
    Console.WriteLine(
        $"{customer.FirstName} {customer.LastName}"
    );
}