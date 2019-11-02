using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface ICourierManager
    {

        ICourierDb CourierDb { get; }

        List<Courier> GetCouriers();

        Courier GetCourier(int id);

        Courier AddCourier(Courier courier);

        int UpdateCourier(Courier courier);

        int DeleteCourier(int id);




    }
}
