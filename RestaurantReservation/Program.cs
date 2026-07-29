using RestaurantReservation.Db.Context;
using RestaurantReservation.Db.Repositories;


var context = new RestaurantReservationDbContext();


var restaurantRepository = new RestaurantRepository(context);

var revenue = await restaurantRepository.CalculateRestaurantRevenue(1);

Console.WriteLine($"Restaurant Revenue: {revenue}");