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
        public ICustomersDB CustomersDb { get; }

        public CustomersManager(IConfiguration configuration)
        {

            CustomersDb = new CustomersDB(configuration);

        }


        public Customer GetCustomer(int id)
        {
            return CustomersDb.GetCustomer(id);
        }

        public Customer AddCustomer(Customer customer)
        {
            return CustomersDb.AddCustomer(customer);
        }

        public int UpdateCustomer(Customer customer)
        {
            return CustomersDb.UpdateCustomer(customer);
        }

        public int DeleteCustomer(int id)
        {
            return CustomersDb.DeleteCustomer(id);
        }

        public Boolean Verify(string login, string password)
        {
            var loginsPasswords = CustomersDb.GetLoginPasswordCustomers();


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
