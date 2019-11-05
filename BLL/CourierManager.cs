using DTO;
using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CourierManager
    {

        public ICourierDB CourierDb { get; }

        public CourierManager(IConfiguration configuration)
        {

            CourierDb = new CourierDB(configuration);

        }

        public List<Courier> GetCouriers()
        {
            return CourierDb.GetCouriers();
        }

        public Courier GetCourier(int id)
        {
            return CourierDb.GetCourier(id);
        }

        public Courier AddCourier(Courier courier)
        {
            return CourierDb.AddCourier(courier);
        }

        public int UpdateCourier(Courier courier)
        {
            return CourierDb.UpdateCourier(courier);
        }

        public int DeleteCourier(int id)
        {
            return CourierDb.DeleteCity(id);
        }



    }
}
