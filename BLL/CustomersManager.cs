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

        public List<Customers> GetHotels()
        {
            return CustomersDb.GetHotel();
        }

        public Customers GetHotel(int id)
        {
            return CustomersDb.GetHotel(id);
        }

        public Customers AddHotel(Customers courier)
        {
            return CustomersDb.AddHotel(courier);
        }

        public int UpdateHotel(Customers courier)
        {
            return CustomersDb.UpdateHotel(courier);
        }

        public int DeleteHotel(int id)
        {
            return CustomersDb.DeleteHotel(id);
        }



    }
}
