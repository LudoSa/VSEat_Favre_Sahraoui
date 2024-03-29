﻿using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface ICustomersManager
    {


        Customer GetCustomer(int id);

        Customer AddCustomer(Customer customer);


        List<string> GetCitiesName();
        int GetCustomerId(String email);

    }
}
