using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public interface ICourierDB
    {
        Courier GetCourier(int id);
        List<Courier> GetCouriers();
        Courier AddCourier(Courier courier);
        int UpdateCourier(Courier courier);
        List<Courier> GetIdCourier(int idCity);
    }
}
