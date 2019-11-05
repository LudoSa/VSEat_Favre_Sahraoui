using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface ICustomersDB
    {
        IConfiguration Configuration { get; }
        List<Customers> GetCustomers();
        Customers GetCustomer(int id);
        Customers AddCustomer(Customers customers);
        int UpdateCustomer(Customers customers);
        int DeleteCustomer(int id);
    }
}
