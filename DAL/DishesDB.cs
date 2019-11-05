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
        public IConfiguration Configuration { get; }

        public DishesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

       

        public Dishes GetDish(int id)
        {
            Dishes dishes = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

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

                            dishes = new Dishes();

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

        public List<Dishes> GetDishes()
        {
            List<Dishes> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Dishes";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Dishes>();

                            Dishes dishes = new Dishes();

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
