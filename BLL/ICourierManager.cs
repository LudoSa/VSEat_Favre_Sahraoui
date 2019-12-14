﻿using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface ICourierManager
    {

        Courier GetCourier(int id);

        Courier AddCourier(Courier courier);

        int UpdateCourier(Courier courier);

        int GetCourierId(String email);
        List<Courier> GetCouriersSameCity(int idCity);

    }
}
