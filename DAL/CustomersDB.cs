using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class CustomersDB : ICustomersDB
    {
        public IConfiguration Configuration { get; }

        public Customers AddCustomer(Customers customers)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    String query = "Insert into Customers(Firstname,Lastname,Login,Password,Country_code) values(@Firstname,@Lastname,@Login,@Password,@Country_code); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Firstname", customers.Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", customers.Lastname);
                    cmd.Parameters.AddWithValue("@Login", customers.Login);
                    cmd.Parameters.AddWithValue("@Password", customers.Password);
                    cmd.Parameters.AddWithValue("@Country_code", customers.Country_code);
                    cn.Open();
                    //courier.IdCourier = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return customers;
        }

        public int DeleteCustomer(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE Customers where IdCustomer = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);


                    cn.Open();

                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public Customers getCustomer(int id)
        {
            Customers customers = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {


                    string query = "Select * from Customers where IdCustomers = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            customers = new Customers();

                            customers.IdCustomer = (int)dr["IdCustomer"];
                            customers.Firstname = (string)dr["Firstname"];
                            customers.Lastname = (string)dr["Lastname"];
                            customers.Login = (String)dr["Login"];
                            customers.Password = (String)dr["Password"];
                            customers.Country_code = (int)dr["Country_code"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return customers;
        }

        public List<Customers> getCustomers()
        {
            List<Customers> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Customers";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Customers>();

                            Customers customers = new Customers();

                            customers.IdCustomer = (int)dr["IdCustomer"];
                            customers.Firstname= (string)dr["Firstname"];
                            customers.Lastname = (string)dr["Lastname"];
                            customers.Login = (string)dr["Login"];
                            customers.Password = (string)dr["Password"];
                            customers.Country_code = (int)dr["Country_code"];

                            results.Add(customers);
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

        public int UpdateCustomer(Customers customers)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Customers SET Firstname=@Firstname, Lastname=@Lastname, Login=@Login, Password=@Password, Country_code=@Countrycode";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", customers.IdCustomer);
                    cmd.Parameters.AddWithValue("@Firstname", customers.Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", customers.Lastname);
                    cmd.Parameters.AddWithValue("@Login", customers.Login);
                    cmd.Parameters.AddWithValue("@Password", customers.Password);
                    cmd.Parameters.AddWithValue("@Countrycode", customers.Country_code);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
