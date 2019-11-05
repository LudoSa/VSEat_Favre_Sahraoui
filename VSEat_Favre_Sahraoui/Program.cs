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
            customerDBManager.AddCustomer(new Customers {Firstname = "Ludovic", Lastname = "Sahraoui", Login="Baba", Password="Test1", Country_code=1, Address="Chemin des Salines 40" });


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



            /*--Dishes--*/



            /*--OrderDishes--*/



            /*--Orders--*/


            /*--Restaurants--*/

        }
    }
}
