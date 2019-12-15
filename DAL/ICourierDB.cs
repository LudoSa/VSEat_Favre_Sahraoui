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
 
        List<Courier> GetIdCourier(int idCity);
    }
}
