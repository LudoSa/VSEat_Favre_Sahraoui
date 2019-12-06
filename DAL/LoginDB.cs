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
                    string query = "SELECT Email, Password FROM Customers, Courier";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Login>();

                            Login login = new Login();

                            login.Email = (string)dr["Login"];
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
    }
}
