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
        public ICustomersDB CustomersDb { get; }

        public CustomersManager(IConfiguration configuration)
        {

            CustomersDb = new CustomersDB(configuration);

        }


        public Customers GetCustomer(int id)
        {
            return CustomersDb.GetCustomer(id);
        }

        public Customers AddCustomer(Customers customer)
        {
            return CustomersDb.AddCustomer(customer);
        }

        public int UpdateCustomer(Customers customer)
        {
            return CustomersDb.UpdateCustomer(customer);
        }

        public int DeleteCustomer(int id)
        {
            return CustomersDb.DeleteCustomer(id);
        }



    }
}
