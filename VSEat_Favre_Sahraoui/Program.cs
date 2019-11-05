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
            var citiesDBManager = new CitiesManager(Configuration);

            var cities = citiesDBManager.GetCities();


            foreach (var City in cities)
            {
                Console.WriteLine(City.ToString());
            }

            //Get on hotel
            /*Console.WriteLine("--NEW HOTEL--");
            var hotel2 = hotelsDBManager.GetHotel(2);
            Console.WriteLine(hotel2.Name);*/

            
            //Add new cities
            Console.WriteLine("--Add Cities--");
            var newCity = citiesDBManager.AddCity(new Cities { Name = "Aigle", Code = 1860 });
            Console.WriteLine($"ID: {newCity.IdCity} Name: {newCity.Name}");
            cities = citiesDBManager.GetCities();
            foreach (var city in cities)
            {
                Console.WriteLine($"ID:{city.IdCity} Name: {city.Name}");
            }

            /*

            //Update hotel
            Console.WriteLine("--Update HOTEL--");
            newHotel.Name = "Le Rhône";
            hotelsDBManager.UpdateHotel(newHotel);
            hotels = hotelsDBManager.GetHotels();
            foreach (var hotel in hotels)
            {
                Console.WriteLine($"ID:{hotel.IdHotel} Name: {hotel.Name}");
            }




            //Delete hotel
            Console.WriteLine("--Delete HOTEL--");
            hotelsDBManager.DeleteHotel(9);
            hotels = hotelsDBManager.GetHotels();
            DisplayHotels(hotelsDBManager);


            */

            /*

            static void DisplayHotels(HotelManager hotelDb)
            {
                var hotels = hotelsDBManager.GetHotels();
                foreach (var hotel in hotels)
                {
                    Console.WriteLine(hotel.Name);
                }
            }

            */

        }
    }
}
