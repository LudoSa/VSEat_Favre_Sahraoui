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
            
            var customerDBManager = new CustomersManager(Configuration);

            //Add new customer
            Console.WriteLine("--Add customer --");
            var newCustomer = customerDBManager.AddCustomer(new Customers { IdCustomer=1, Firstname = "Ludovic", Lastname = "Sahraoui", Login="Baba", Password="Test1", Country_code=1, Address="Chemin des Salines 40" });
            
            




        }
    }
}
