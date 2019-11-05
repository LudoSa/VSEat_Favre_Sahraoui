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

        public Dishes AddDish(Dishes dishes)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    String query = "Insert into Dishes(Name,Price,Status,Created_at,Restaurants_id) values(@Name,@Price,@Status,@Created_at,@Restaurants_id); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Name", dishes.Name);
                    cmd.Parameters.AddWithValue("@Price", dishes.Price);
                    cmd.Parameters.AddWithValue("@Status", dishes.Status);
                    cmd.Parameters.AddWithValue("@Created_at", dishes.Created_at);
                    cmd.Parameters.AddWithValue("@Restaurants_id", dishes.Restaurants_id);
                    cn.Open();
                    dishes.IdDishes = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return dishes;
        }

        public int DeleteDish(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE Dishes where IdDishes = @id";
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
                            dishes.Created_at = (int)dr["Created_at"];
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
                            dishes.Created_at = (int)dr["Created_at"];
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

        public int UpdateDish(Dishes dishes)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Dishes SET Name=@Name, Price=@Price, Status=@Status, Created_at=@Created_at, Restaurants_id=@Restaurants_id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", dishes.IdDishes);
                    cmd.Parameters.AddWithValue("@Name", dishes.Name);
                    cmd.Parameters.AddWithValue("@Price", dishes.Price);
                    cmd.Parameters.AddWithValue("@Status", dishes.Status);
                    cmd.Parameters.AddWithValue("@Created_at", dishes.Created_at);
                    cmd.Parameters.AddWithValue("@Restaurants_id", dishes.Restaurants_id);

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
