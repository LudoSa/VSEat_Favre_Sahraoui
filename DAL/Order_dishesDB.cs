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

        public OrderDishes AddOrderDish(OrderDishes orderdishes)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    String query = "Insert into Order_dishes(IdDish,Quantity) values(@IdDish,@Quantity); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdDish", orderdishes.IdDish);
                    cmd.Parameters.AddWithValue("@Quantity", orderdishes.Quantity);
          
                    cn.Open();
                    orderdishes.IdOrder = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return orderdishes;
        }

        public int DeleteOrderDish(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE Order_dishes where IdOrder = @id";
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

        public OrderDishes GetOrderDish(int id)
        {
            OrderDishes orderdishes = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {


                    string query = "Select * from Order_dishes where IdOrder_dishes = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            orderdishes = new OrderDishes();

                            orderdishes.IdOrder = (int)dr["IdOrder"];
                            orderdishes.IdDish = (int)dr["IdDish"];
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

        public List<OrderDishes> GetOrderDishes()
        {
            List<OrderDishes> results = null;
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
                                results = new List<OrderDishes>();

                            OrderDishes orderDishes = new OrderDishes();

                            orderDishes.IdOrder = (int)dr["IdOrder"];
                            orderDishes.IdDish = (int)dr["IdDish"];
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

        public int UpdateOrderDish(OrderDishes orderdishes)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Order_dishes SET IdOrder=@IdOrder, IdDish=@IdDish, Quantity=@Quantity";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdOrder", orderdishes.IdOrder);
                    cmd.Parameters.AddWithValue("@IdDish", orderdishes.IdDish);
                    cmd.Parameters.AddWithValue("@Quantity", orderdishes.Quantity);

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
