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

        public IOrdersDB OrderDbObject { get; }
        public CourierManager(ICourierDB courierDb)
        {

            CourierDbObject = courierDb;

        }

        public Courier GetCourier(int id)
        {
            return CourierDbObject.GetCourier(id);
        }

        public int GetCourierId(String email)
        {

            List<Courier> couriers = CourierDbObject.GetCouriers();

            foreach(Courier courier in couriers)
            {

                if (courier.Email.Equals(email))
                {
                    return courier.IdCourier;
                }
            }

            return 0;
        }



        public List<Courier> GetIdCourier(int idCity)
        {
            return CourierDbObject.GetIdCourier(idCity);
        }

    }
}
