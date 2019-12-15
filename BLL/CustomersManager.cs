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

                    return CustomersDbObject.AddCustomer(customer);
        }

        

        public List<string> GetCitiesName()
        {
            return CitiesDB.GetNames();
        }

        public int GetCustomerId(String email)
        {

            List<Customer> customers = CustomersDbObject.GetCustomers();

            foreach (Customer customer in customers)
            {

                if (customer.Email.Equals(email))
                {
                    return customer.IdCustomer;
                }
            }

            return 0;
        }

    }
}
