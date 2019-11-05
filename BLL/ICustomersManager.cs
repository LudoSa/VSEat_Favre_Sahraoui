using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface ICustomersManager
    {

        ICustomersDB CustomersDb { get; }


        Customers GetCustomer(int id);

        Customers AddCustomer(Customers customer);

        int UpdateCustomer(Customers customer);

        int DeleteCustomer(int id);


    }
}
