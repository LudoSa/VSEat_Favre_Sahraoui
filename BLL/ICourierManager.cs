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

        int GetCourierId(String email);
        List<Courier> GetIdCourier(int idCity);

    }
}
