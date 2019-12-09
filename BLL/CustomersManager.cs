using DTO;
using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CustomersManager : ICustomersManager
    {
        public ICustomersDB CustomersDbObject { get; }

        public ICitiesDB CitiesDB { get; }

        public CustomersManager(ICustomersDB customersDB, ICitiesDB citiesDB)
        {

            CustomersDbObject = customersDB;
            CitiesDB = citiesDB;
        }


        public Customer GetCustomer(int id)
        {
            return CustomersDbObject.GetCustomer(id);
        }

        public Customer AddCustomer(Customer customer)
        {

            var cities = CitiesDB.GetCities();

            foreach(var city in cities)
            {
                if (customer.Country_code.Equals(city.Name))
                {
                    customer.Country_code=city.IdCity;
                    return CustomersDbObject.AddCustomer(customer);
                }
            }

            return null;
        }

        public int UpdateCustomer(Customer customer)
        {
            return CustomersDbObject.UpdateCustomer(customer);
        }

        public int DeleteCustomer(int id)
        {
            return CustomersDbObject.DeleteCustomer(id);
        }

        public List<string> GetCitiesName()
        {
            return CitiesDB.GetNames();
        }

    }
}
