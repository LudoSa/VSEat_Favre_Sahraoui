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

        public List<Courier> GetCouriers()
        {
            return CourierDb.GetHotel();
        }

        public Courier GetCourier(int id)
        {
            return CourierDb.GetHotel(id);
        }

        public Courier AddCourier(Courier courier)
        {
            return CourierDb.AddHotel(courier);
        }

        public int UpdateCourier(Courier courier)
        {
            return CourierDb.UpdateHotel(courier);
        }

        public int DeleteCourier(int id)
        {
            return CourierDb.DeleteHotel(id);
        }



    }
}
