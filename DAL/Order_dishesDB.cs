using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class Order_dishesDB : IOrder_dishesDB
    {
        private string connectionString = null;

        public Order_dishesDB(IConfiguration configuration)
        {
            var Config = configuration;
            connectionString = Config.GetConnectionString("DefaultConnection");
        }

       
        public void AddOrderDishes(OrderDish orderDish)
        {

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    String query = "INSERT INTO Order_dishes(IdOrder,IdDishes,Quantity) values(@IdOrder,@IdDishes,@Quantity)";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdDishes", orderDish.IdDishes);
                    cmd.Parameters.AddWithValue("@IdOrder", orderDish.IdOrder);
                    cmd.Parameters.AddWithValue("@Quantity", orderDish.Quantity);
                    cn.Open();
                    cmd.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public OrderDish GetOrderDish(int id)
        {
            OrderDish orderdishes = null;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {


                    string query = "Select * from Order_dishes where IdOrderDishes = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            orderdishes = new OrderDish();

                            orderdishes.IdOrder = (int)dr["IdOrder"];
                            orderdishes.IdDishes = (int)dr["IdDishes"];
                            orderdishes.Quantity = (int)dr["Quantity"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return orderdishes;
        }

        public List<OrderDish> GetOrderDishes()
        {
            List<OrderDish> results = null;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Order_dishes";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<OrderDish>();

                            OrderDish orderDishes = new OrderDish();

                            orderDishes.IdOrder = (int)dr["IdOrder"];
                            orderDishes.IdDishes = (int)dr["IdDishes"];
                            orderDishes.Quantity = (int)dr["Quantity"];
                      
                            results.Add(orderDishes);
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
