using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class OrdersDB : IOrdersDB
    {
        private string connectionString = null;

        public OrdersDB(IConfiguration configuration)
        {
            var Config = configuration;
            connectionString = Config.GetConnectionString("DefaultConnection");
        }

        public Order AddOrder(Order orders)
        {
           

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    String query = "Insert into Orders(Status,Created_at,Delivery_time,IdCustomer,IdCourier) values(@Status,@Created_at,@Delivery_time,@IdCustomer,@IdCourier); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Status", orders.Status);
                    cmd.Parameters.AddWithValue("@Created_at", orders.Created_at);
                    cmd.Parameters.AddWithValue("@Delivery_time", orders.Delivery_time);
                    cmd.Parameters.AddWithValue("@IdCustomer", orders.IdCustomer);
                    cmd.Parameters.AddWithValue("@IdCourier", orders.IdCourier);
                    cn.Open();
                    orders.IdOrder = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return orders;
        }

        public int DeleteOrder(int id)
        {
            int result = 0;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE Orders where IdOrder = @id";
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

        public Order GetOrder(int id)
        {
            Order orders = null;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {


                    string query = "Select * from Orders where IdOrder = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            orders = new Order();

                            orders.IdOrder = (int)dr["IdOrder"];
                            orders.Status = (string)dr["Status"];
                            orders.Created_at = (long)dr["Created_at"];
                            orders.Delivery_time = (int)dr["Delivery_time"];
                            orders.IdCustomer = (int)dr["IdCustomer"];
                            orders.IdCourier = (int)dr["IdCourier"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return orders;
        }

        public List<Order> GetCourierOrders(int id)
        {
            List<Order> results = null;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Orders WHERE IdCourier = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order>();

                            Order orders = new Order();

                            orders.IdOrder = (int)dr["IdOrder"];
                            orders.Status = (string)dr["Status"];
                            orders.Created_at = (long)dr["Created_at"];
                            orders.Delivery_time = (int)dr["Delivery_time"];
                            orders.IdCustomer = (int)dr["IdCustomer"];
                            orders.IdCourier = (int)dr["IdCourier"];

                            results.Add(orders);
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

        public int UpdateOrder(Order orders)
        {
            int result = 0;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Orders SET Status=@Status, Created_at=@Created_at, Delivery_time=@Delivery_time, IdCustomer=@IdCustomer, IdCourier=@IdCourier";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", orders.IdOrder);
                    cmd.Parameters.AddWithValue("@Status", orders.Status);
                    cmd.Parameters.AddWithValue("@Created_at", orders.Created_at);
                    cmd.Parameters.AddWithValue("@Delivery_time", orders.Delivery_time);
                    cmd.Parameters.AddWithValue("@IdCustomer", orders.IdCustomer);
                    cmd.Parameters.AddWithValue("@IdCourier", orders.IdCourier);

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
