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
        public IConfiguration Configuration { get; }

        public Order_dishesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

       

        public OrderDish GetOrderDish(int id)
        {
            OrderDish orderdishes = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

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

        public int UpdateOrderDish(OrderDish orderDishes)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Order_dishes SET IdOrder=@IdOrder, IdDishes=@IdDishes, Quantity=@Quantity";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdOrder", orderDishes.IdOrder);
                    cmd.Parameters.AddWithValue("@IdDishes", orderDishes.IdDishes);
                    cmd.Parameters.AddWithValue("@Quantity", orderDishes.Quantity);

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
