using Microsoft.Extensions.Configuration;
using System;
using BLL;
using DTO;
using System.IO;
using System.Configuration;

namespace VSEat_Favre_Sahraoui
{
    class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        static void Main(string[] args)
        {
            
            /*--Customers--*/

            var customerDBManager = new CustomersManager(Configuration);

            //Add new customer
            Console.WriteLine("--Add customer --");
            customerDBManager.AddCustomer(new Customers { Firstname = "Ludovic", Lastname = "Sahraoui", Login = "Baba", Password = "Test1", Country_code = 1, Address = "Chemin des Salines 40" }); ;


            //Delete customer
            Console.WriteLine("--Delete customer --");
            customerDBManager.DeleteCustomer(1);


            /*--Cities--*/
            //Get Cities
            Console.WriteLine("--Get cities --");
            var citiesDBManager = new CitiesManager(Configuration);
            var cities = citiesDBManager.GetCities();
            foreach (var city in cities)
            {
                Console.WriteLine(city.Name);
            }


            /*--Courier--*/
            Console.WriteLine("--Get courier 1 --");
            var courierDBManager = new CourierManager(Configuration);
            var courier = courierDBManager.GetCourier(1);
            Console.WriteLine(courier.Firstname);

            /*--Dishes--*/


            //Get dishes
            Console.WriteLine("--Get dishes --");
            var dishesDBManager = new DishesManager(Configuration);
            var dishes=dishesDBManager.GetDishes();

            foreach (var dish in dishes)
            {
                Console.WriteLine(dish.Name);
            }

            /*--OrderDishes--*/



            /*--Orders--*/

            //add order
            Console.WriteLine("--Add order --");
            var ordersDBManager = new OrdersManager(Configuration);
            ordersDBManager.AddOrder(new Orders { Status = "Ready", Created_at = 02042019, Delivery_time = 2, IdCourier = 1, IdCustomer = 1 }); ;


            /*--Restaurants--*/

        }
    }
}
