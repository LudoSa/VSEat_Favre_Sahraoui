using DTO;
using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CustomersManager
    {
        public ICustomersDB CustomersDb { get; }

        public CustomersManager(IConfiguration configuration)
        {

            CustomersDb = new CustomersDB(configuration);

        }

        public List<Customers> GetCustomers()
        {
            return CustomersDb.GetCustomers();
        }

        public Customers GetCustomer(int id)
        {
            return CustomersDb.GetCustomer(id);
        }

        public Customers AddCustomer(Customers courier)
        {
            return CustomersDb.AddCustomer(courier);
        }

        public int UpdateCustomer(Customers courier)
        {
            return CustomersDb.UpdateCustomer(courier);
        }

        public int DeleteCustomer(int id)
        {
            return CustomersDb.DeleteCustomer(id);
        }



    }
}
