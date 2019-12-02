using DTO;
using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CustomersManager : ICustomersManager
    {
        public ICustomersDB CustomersDbObject { get; }

        public CustomersManager(ICustomersDB customersDB)
        {

            CustomersDbObject = customersDB;

        }


        public Customer GetCustomer(int id)
        {
            return CustomersDbObject.GetCustomer(id);
        }

        public Customer AddCustomer(Customer customer)
        {
            return CustomersDbObject.AddCustomer(customer);
        }

        public int UpdateCustomer(Customer customer)
        {
            return CustomersDbObject.UpdateCustomer(customer);
        }

        public int DeleteCustomer(int id)
        {
            return CustomersDbObject.DeleteCustomer(id);
        }

        public Boolean Verify(string login, string password)
        {
            var loginsPasswords = CustomersDbObject.GetLoginPasswordCustomers();


            foreach (var loginPassword in loginsPasswords)
            {
                string loginDB = loginPassword.Login;
                string passwordDB = loginPassword.Password;

                if (login.Equals(loginDB) && password.Equals(passwordDB))
                {
                    return true;
                }

            }
            return false;
        }

    }
}
