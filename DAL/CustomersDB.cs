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
        private string connectionString = null;

        public CustomersDB(IConfiguration configuration)
        {
            var Config = configuration;
            connectionString = Config.GetConnectionString("DefaultConnection");
        }

        public Customer AddCustomer(Customer customers)
        {
           

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    String query = "INSERT INTO Customers(Firstname,Lastname,Email,Password,Address,Country_code) values(@Firstname,@Lastname,@Email,@Password,@Address,@Country_code); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Firstname", customers.Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", customers.Lastname);
                    cmd.Parameters.AddWithValue("@Email", customers.Email);
                    cmd.Parameters.AddWithValue("@Password", customers.Password);
                    cmd.Parameters.AddWithValue("@Address", customers.Address);
                    cmd.Parameters.AddWithValue("@Country_code", customers.Country_code);
                    cn.Open();
                    customers.IdCustomer = Convert.ToInt32(cmd.ExecuteScalar());
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


        public List<Customer> GetCustomers()
        {
            List<Customer> results = null;


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Customers";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Customer>();

                            Customer customer = new Customer();

                            customer.IdCustomer = (int)dr["IdCustomer"];
                            customer.Firstname = (string)dr["Firstname"];
                            customer.Lastname = (String)dr["Lastname"];
                            customer.Country_code = (int)dr["Country_code"];
                            customer.Email = (String)dr["Email"];
                            customer.Password = (String)dr["Password"];
                            customer.Address = (String)dr["Address"];

                            results.Add(customer);
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
        public Customer GetCustomer(int id)
        {
            Customer customers = null;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {


                    string query = "SELECT * from Customers WHERE IdCustomer = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            customers = new Customer();

                            customers.IdCustomer = (int)dr["IdCustomer"];
                            customers.Firstname = (string)dr["Firstname"];
                            customers.Lastname = (string)dr["Lastname"];
                            customers.Email = (String)dr["Email"];
                            customers.Password = (String)dr["Password"];
                            customers.Address = (string)dr["Address"];
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

        public int UpdateCustomer(Customer customers)
        {
            int result = 0;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Customers SET Firstname=@Firstname, Lastname=@Lastname, Email=@Email, Password=@Password, Address=@Address, Country_code=@Countrycode";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", customers.IdCustomer);
                    cmd.Parameters.AddWithValue("@Firstname", customers.Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", customers.Lastname);
                    cmd.Parameters.AddWithValue("@Email", customers.Email);
                    cmd.Parameters.AddWithValue("@Password", customers.Password);
                    cmd.Parameters.AddWithValue("@Address", customers.Address);
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
