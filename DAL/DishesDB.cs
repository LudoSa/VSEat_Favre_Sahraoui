using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class DishesDB : IDishesDB
    {
        private string connectionString = null;

        public DishesDB(IConfiguration configuration)
        {
            var Config = configuration;
            connectionString = Config.GetConnectionString("DefaultConnection");
        }

       

        public Dish GetDish(int id)
        {
            Dish dishes = null; 

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {


                    string query = "Select * from Dishes where IdDishes = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            dishes = new Dish();

                            dishes.IdDishes = (int)dr["IdDishes"];
                            dishes.Price = (int)dr["Price"];
                            dishes.Status= (string)dr["Status"];
                            dishes.Created_at = (string)dr["Created_at"];
                            dishes.Restaurants_id = (int)dr["Restaurants_id"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dishes;
        }

        public List<Dish> GetDishes(int id)
        {
            List<Dish> results = null;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Dishes WHERE Restaurants_id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Dish>();

                            Dish dishes = new Dish();

                            dishes.IdDishes = (int)dr["IdDishes"];
                            dishes.Name = (string)dr["Name"];
                            dishes.Price = (int)dr["Price"];
                            dishes.Status = (string)dr["Status"];
                            dishes.Created_at = (string)dr["Created_at"];
                            dishes.Restaurants_id = (int)dr["Restaurants_id"];

                            results.Add(dishes);
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
