using DTO;
using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CourierManager : ICourierManager
    {

        public ICourierDB CourierDbObject { get; }

        public CourierManager(ICourierDB courierDb)
        {

            CourierDbObject = courierDb;

        }

        public Courier GetCourier(int id)
        {
            return CourierDbObject.GetCourier(id);
        }

        public Courier AddCourier(Courier courier)
        {
            return CourierDbObject.AddCourier(courier);
        }

        public int UpdateCourier(Courier courier)
        {
            return CourierDbObject.UpdateCourier(courier);
        }




    }
}
