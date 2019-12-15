using System;
using System.Collections.Generic;
using DTO;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class LoginDB : IloginDB
    {

        private string connectionString = null;
        public LoginDB(IConfiguration configuration)
        {
            var Config = configuration;
            connectionString = Config.GetConnectionString("DefaultConnection");
        }


        public List<Login> GetCustomerLoginPassword()
        {

            List<Login> results = null;


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Email, Password FROM Customers";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Login>();

                            Login login = new Login();

                            login.Email = (string)dr["Email"];
                            login.Password = (string)dr["Password"];

                            results.Add(login);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;
        }


        public List<Login> GetLoginPassword()
        {

            List<Login> results = null;


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Email, Password FROM Customers UNION SELECT Email, Password FROM Courier";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Login>();

                            Login login = new Login();

                            login.Email = (string)dr["Email"];
                            login.Password = (string)dr["Password"];

                            results.Add(login);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;
        }

        public int GetIdCustomer(string email)
        {

            int idCustomer = 0;


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {


                    string query = "Select IdCustomer from Customers where Email = @email";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@email", email);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            idCustomer = (int)dr["IdCustomer"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return idCustomer;

        }
    }
}
