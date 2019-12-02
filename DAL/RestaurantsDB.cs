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


        private string connectionString = null;

        public RestaurantsDB(IConfiguration configuration)
        {
            var Config = configuration;
            connectionString = Config.GetConnectionString("DefaultConnection");
        }

        

        public Restaurant GetRestaurant(int id)
        {
            Restaurant restaurants = null;
            

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

                            restaurants = new Restaurant();

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

        public List<Restaurant> GetRestaurants()
        {
            List<Restaurant> results = null;
            

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
                                results = new List<Restaurant>();

                            Restaurant restaurants = new Restaurant();

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

       
    }
}
