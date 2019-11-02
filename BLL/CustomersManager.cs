using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CustomersManager
    {
        public ICustomers CustomersDb { get; }

        public CustomersManager(IConfiguration configuration)
        {

            CustomersDb = new CustomersDb(configuration);

        }

        public List<Customers> GetCustomers()
        {
            return CustomersDb.GetHotel();
        }

        public Customers GetCustomer(int id)
        {
            return CustomersDb.GetHotel(id);
        }

        public Customers AddCustomer(Customers courier)
        {
            return CustomersDb.AddHotel(courier);
        }

        public int UpdateCustomer(Customers courier)
        {
            return CustomersDb.UpdateHotel(courier);
        }

        public int DeleteCustomer(int id)
        {
            return CustomersDb.DeleteHotel(id);
        }



    }
}
