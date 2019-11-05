using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public interface ICourierDB
    {
        IConfiguration Configuration { get; }
        Courier GetCourier(int id);
        Courier AddCourier(Courier courier);
        int UpdateCourier(Courier courier);
        int DeleteCourier(int id);
    }
}
