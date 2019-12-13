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
                    String query = "INSERT INTO Orders(Status,Delivery_time,IdCustomer,IdCourier) values(@Status,@Delivery_time,@IdCustomer,@IdCourier); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Status", orders.Status);
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
                            orders.Delivery_time = (DateTime)dr["Delivery_time"];
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

        //Méthode qui récupère toutes les informations des commandes en cours pour un livreur en prenant l'id du livreur en attribut
        public List<Order> GetCourierOrders(int id)
        {
            List<Order> results = null;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "SELECT Orders.IdOrder, Orders.Status, Orders.Delivery_time, Orders.IdCustomer, Orders.IdOrder, Order_dishes.Quantity,  Customers.Firstname, Customers.Lastname, (Dishes.Price*Order_dishes.Quantity) AS FinalPrice, Dishes.Name, Customers.Address, Customers.Country_code, Cities.Code, Cities.Name AS CityName FROM Orders " +
                        "LEFT JOIN Customers ON Customers.IdCustomer = Orders.IdCustomer " +
                        "INNER JOIN Order_dishes ON Order_dishes.IdOrder = Orders.IdOrder " +
                        "LEFT JOIN Dishes ON Dishes.IdDishes = Order_dishes.IdDishes " +
                        "LEFT JOIN Cities ON Cities.IdCity = Customers.Country_code " +
                        "WHERE Orders.IdCourier = @id AND NOT Orders.Status='Delivered'";
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
                            orders.Delivery_time = (DateTime)dr["Delivery_time"];
                            orders.IdCustomer = (int)dr["IdCustomer"];
                            orders.IdOrder = (int)dr["IdOrder"];
                            orders.CustomerName = (string)dr["Firstname"] + " " + dr["Lastname"];
                            orders.Quantity = (int)dr["Quantity"];
                            orders.Price = (int)dr["FinalPrice"];
                            orders.DishName = (string)dr["Name"];
                            orders.Address = (string)dr["Address"] + ", " + dr["Code"] + " " + dr["CityName"];

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

        //Méthode qui récupère toutes les informations des commandes livrées pour un livreur en prenant l'id du livreur en attribut
        public List<Order> GetArchivedCourierOrders(int id)
        {
            List<Order> results = null;


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {

                    string query = "SELECT Orders.IdOrder, Orders.Status, Orders.Delivery_time, Orders.IdCustomer, Orders.IdOrder, Order_dishes.Quantity,  Customers.Firstname, Customers.Lastname, (Dishes.Price*Order_dishes.Quantity) AS FinalPrice, Dishes.Name, Customers.Address, Customers.Country_code, Cities.Code, Cities.Name AS CityName FROM Orders " +
                        "LEFT JOIN Customers ON Customers.IdCustomer = Orders.IdCustomer " +
                        "INNER JOIN Order_dishes ON Order_dishes.IdOrder = Orders.IdOrder " +
                        "LEFT JOIN Dishes ON Dishes.IdDishes = Order_dishes.IdDishes " +
                        "LEFT JOIN Cities ON Cities.IdCity = Customers.Country_code " +
                        "WHERE Orders.IdCourier = @id AND NOT Orders.Status='Ready'";
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
                            orders.Delivery_time = (DateTime)dr["Delivery_time"];
                            orders.IdCustomer = (int)dr["IdCustomer"];
                            orders.IdOrder = (int)dr["IdOrder"];
                            orders.CustomerName = (string)dr["Firstname"] + " " + dr["Lastname"];
                            orders.Quantity = (int)dr["Quantity"];
                            orders.Price = (int)dr["FinalPrice"];
                            orders.DishName = (string)dr["Name"];
                            orders.Address = (string)dr["Address"] + ", " + dr["Code"] + " " + dr["CityName"];

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
                    string query = "UPDATE Orders SET Status=@Status, Delivery_time=@Delivery_time, IdCustomer=@IdCustomer, IdCourier=@IdCourier WHERE IdOrder=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", orders.IdOrder);
                    cmd.Parameters.AddWithValue("@Status", orders.Status);
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
