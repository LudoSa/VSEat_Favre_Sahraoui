using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class RestaurantsDB : IRestaurantsDB
    {
        public IConfiguration Configuration { get; }

        public Restaurants AddRestaurant(Restaurants restaurants)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    String query = "Insert into Customers(Merchant_name,Address,Country_code) values(@Merchant_name,@Address,@Country_code); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Merchant_name", restaurants.Merchant_name);
                    cmd.Parameters.AddWithValue("@Address", restaurants.Address);
                    cmd.Parameters.AddWithValue("@Country_code", restaurants.Country_code);
                  
                    cn.Open();
                    restaurants.IdRestaurant = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return restaurants;
        }

        public int DeleteRestaurant(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE Restaurants where IdRestaurant = @id";
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

        public Restaurants GetRestaurant(int id)
        {
            Restaurants restaurants = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {


                    string query = "Select * from Restaurants where IdRestaurant = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            restaurants = new Restaurants();

                            restaurants.IdRestaurant = (int)dr["IdRestaurant"];
                            restaurants.Merchant_name = (string)dr["Merchant_name"];
                            restaurants.Address = (string)dr["Address"];
                            restaurants.Country_code = (int)dr["Country_code"];
                          
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restaurants;
        }

        public List<Restaurants> GetRestaurants()
        {
            List<Restaurants> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Restaurants";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Restaurants>();

                            Restaurants restaurants = new Restaurants();

                            restaurants.IdRestaurant = (int)dr["IdRestaurant"];
                            restaurants.Merchant_name = (string)dr["Merchant_name"];
                            restaurants.Address = (string)dr["Address"];
                            restaurants.Country_code = (int)dr["Country_code"];

                            results.Add(restaurants);
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

        public int UpdateRestaurant(Restaurants restaurants)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Restaurants SET Merchant_name=@Merchant_name, Address=@Address, Country_code=@Country_code";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", restaurants.IdRestaurant);
                    cmd.Parameters.AddWithValue("@Merchant_name", restaurants.Merchant_name);
                    cmd.Parameters.AddWithValue("@Address", restaurants.Address);
                    cmd.Parameters.AddWithValue("@Country_code", restaurants.Country_code);
                   
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
