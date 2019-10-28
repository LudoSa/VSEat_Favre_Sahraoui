using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class OrdersManager
    {


        public IOrders OrdersDb { get; }

        public OrdersManager(IConfiguration configuration)
        {

            OrdersDb = new CourierDb(configuration);

        }

        public List<Orders> GetHotels()
        {
            return OrdersDb.GetHotel();
        }

        public Orders GetHotel(int id)
        {
            return OrdersDb.GetHotel(id);
        }

        public Orders AddHotel(Orders courier)
        {
            return OrdersDb.AddHotel(courier);
        }

        public int UpdateHotel(Orders courier)
        {
            return OrdersDb.UpdateHotel(courier);
        }

        public int DeleteHotel(int id)
        {
            return CourierDb.DeleteHotel(id);
        }

    }
}
