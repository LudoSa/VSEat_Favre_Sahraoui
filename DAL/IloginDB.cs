using System;
using System.Collections.Generic;
using DTO;
using System.Text;

namespace DAL
{
    public interface IloginDB
    {

        List<Login> GetCustomerLoginPassword();
        List<Login> GetLoginPassword();

        int GetIdCustomer(string email);
    }
}
