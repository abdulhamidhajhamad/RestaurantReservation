using RestaurantReservation.Db.Context;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories;


var context = new RestaurantReservationDbContext();


//customer
var customerRepository = new CustomerRepository(context);

var customer = new Customer
{
    FirstName = "Ahmad",
    LastName = "Hamad",
    Email = "ahmad@test.com",
    PhoneNumber = "0599999999"
};

await customerRepository.CreateCustomer(customer);

var customers = await customerRepository.GetAllCustomers();

foreach (var c in customers)
{
    Console.WriteLine($"Customer: {c.FirstName} {c.LastName}");
}

customer.FirstName = "Mohammad";

await customerRepository.UpdateCustomer(customer);



//rest

var restaurantRepository = new RestaurantRepository(context);

var restaurant = new Restaurant
{
    Name = "Al Nakheel Restaurant",
    Address = "Nablus",
    PhoneNumber = "0599999999",
    OpeningHours = "Mon-Sun 09:00-23:00"
};

await restaurantRepository.CreateRestaurant(restaurant);

var restaurants = await restaurantRepository.GetAllRestaurants();

foreach (var r in restaurants)
{
    Console.WriteLine($"Restaurant: {r.Name}");
}

restaurant.Name = "Updated Restaurant";

await restaurantRepository.UpdateRestaurant(restaurant);



//emp

var employeeRepository = new EmployeeRepository(context);

var employee = new Employee
{
    FirstName = "Ali",
    LastName = "Hassan",
    Position = "Waiter",
    RestaurantId = restaurant.RestaurantId
};

await employeeRepository.CreateEmployee(employee);

var employees = await employeeRepository.GetAllEmployees();

foreach (var e in employees)
{
    Console.WriteLine($"Employee: {e.FirstName} {e.LastName}");
}

employee.FirstName = "Ahmad";

await employeeRepository.UpdateEmployee(employee);



//table

var tableRepository = new TableRepository(context);

var table = new Table
{
    Capacity = 4,
    RestaurantId = restaurant.RestaurantId
};

await tableRepository.CreateTable(table);

var tables = await tableRepository.GetAllTables();

foreach (var t in tables)
{
    Console.WriteLine($"Table: {t.TableId}");
}

table.Capacity = 6;

await tableRepository.UpdateTable(table);



//menuiteam

var menuItemRepository = new MenuItemRepository(context);

var menuItem = new MenuItem
{
    Name = "Burger",
    Description = "Cheese Burger",
    Price = 20,
    RestaurantId = restaurant.RestaurantId
};

await menuItemRepository.CreateMenuItem(menuItem);

var menuItems = await menuItemRepository.GetAllMenuItems();

foreach (var item in menuItems)
{
    Console.WriteLine($"Menu Item: {item.Name}");
}

menuItem.Price = 25;

await menuItemRepository.UpdateMenuItem(menuItem);



//reservationRepository

var reservationRepository = new ReservationRepository(context);

var reservation = new Reservation
{
    CustomerId = customer.CustomerId,
    RestaurantId = restaurant.RestaurantId,
    TableId = table.TableId,
    ReservationDate = DateTime.Now,
    PartySize = 4
};

await reservationRepository.CreateReservation(reservation);

var reservations = await reservationRepository.GetAllReservations();

foreach (var r in reservations)
{
    Console.WriteLine($"Reservation: {r.ReservationId}");
}

await reservationRepository.UpdateReservation(reservation);



//order

var orderRepository = new OrderRepository(context);

var order = new Order
{
    ReservationId = reservation.ReservationId,
    EmployeeId = employee.EmployeeId,
    OrderDate = DateTime.Now
};

await orderRepository.CreateOrder(order);

var orders = await orderRepository.GetAllOrders();

foreach (var o in orders)
{
    Console.WriteLine($"Order: {o.OrderId}");
}

await orderRepository.UpdateOrder(order);



// oreder

var orderItemRepository = new OrderItemRepository(context);

var orderItem = new OrderItem
{
    OrderId = order.OrderId,
    ItemId = menuItem.ItemId,
    Quantity = 2
};

await orderItemRepository.CreateOrderItem(orderItem);

var orderItems = await orderItemRepository.GetAllOrderItems();

foreach (var oi in orderItems)
{
    Console.WriteLine($"Order Item: {oi.OrderItemId}");
}

await orderItemRepository.UpdateOrderItem(orderItem);



// delete test

await orderItemRepository.DeleteOrderItem(orderItem.OrderItemId);

await orderRepository.DeleteOrder(order.OrderId);

await reservationRepository.DeleteReservation(reservation.ReservationId);

await menuItemRepository.DeleteMenuItem(menuItem.ItemId);

await tableRepository.DeleteTable(table.TableId);

await employeeRepository.DeleteEmployee(employee.EmployeeId);

await restaurantRepository.DeleteRestaurant(restaurant.RestaurantId);

await customerRepository.DeleteCustomer(customer.CustomerId);


Console.WriteLine("All Repository Methods Tested Successfully!");