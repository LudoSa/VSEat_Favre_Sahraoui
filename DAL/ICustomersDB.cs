using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface ICustomersDB
    {
        Customer GetCustomer(int id);
        Customer AddCustomer(Customer customers);
        int UpdateCustomer(Customer customers);
        int DeleteCustomer(int id);
        List<Customer> GetCustomers();
    }
}
