using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CourierManager
    {

        public ICourier CourierDb { get; }

        public CourierManager(IConfiguration configuration)
        {

            CourierDb = new CourierDb(configuration);

        }

        public List<Courier> GetHotels()
        {
            return CourierDb.GetHotel();
        }

        public Courier GetHotel(int id)
        {
            return CourierDb.GetHotel(id);
        }

        public Courier AddHotel(Courier courier)
        {
            return CourierDb.AddHotel(courier);
        }

        public int UpdateHotel(Courier courier)
        {
            return CourierDb.UpdateHotel(courier);
        }

        public int DeleteHotel(int id)
        {
            return CourierDb.DeleteHotel(id);
        }



    }
}
