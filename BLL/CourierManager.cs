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

        public Courier AddCourier(Courier courier)
        {
            return CourierDbObject.AddCourier(courier);
        }

        public int UpdateCourier(Courier courier)
        {
            return CourierDbObject.UpdateCourier(courier);
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

        public List<Courier> GetCouriersSameCity(int idCity)
        {
            throw new NotImplementedException();
        }

        /*
        public int GetFreeCourier(DateTime Delivery_time, int idCity)
        {


            List<Courier> couriers = CourierDbObject.GetCouriersSameCity(idCity);

            List<Courier> couriers = 

            foreach()
            {
                if(count>)   
            int Count
            }


            return CourierDbObject.GetFreeCourier(Delivery_time, idCourier);

        }*/
    }
}
