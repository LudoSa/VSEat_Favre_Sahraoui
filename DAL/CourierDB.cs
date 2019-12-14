using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class CourierDB : ICourierDB
    {
        private string connectionString = null;

        public CourierDB(IConfiguration configuration)
        {
            var Config = configuration;
            connectionString = Config.GetConnectionString("DefaultConnection");
        }

        //Add a courier
        public Courier AddCourier(Courier courier)
        {
           

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    String query = "Insert into Courier(Firstname,Lastname,Country_code,Email,Password) values(@Firstname,@Lastname,@Country_code,@Email,@Password); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Firstname", courier.Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", courier.Lastname);
                    cmd.Parameters.AddWithValue("@Country_code", courier.Country_code);
                    cmd.Parameters.AddWithValue("@Email", courier.Email);
                    cmd.Parameters.AddWithValue("@Password", courier.Password);
                    cn.Open();
                    //courier.IdCourier = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return courier;
        }

        //get a list of courier
        public List<Courier> GetCouriers()
        {
            List<Courier> results = null;


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Courier";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Courier>();

                            Courier courier = new Courier();

                            courier.IdCourier = (int)dr["IdCourier"];
                            courier.Firstname = (string)dr["Firstname"];
                            courier.Lastname = (String)dr["Lastname"];
                            courier.Country_code = (int)dr["Country_code"];
                            courier.Email = (String)dr["Email"];
                            courier.Password = (String)dr["Password"];

                            results.Add(courier);
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

       // get a courier from and id as parameter
        public Courier GetCourier(int id)
        {
            Courier courier = null;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {


                    string query = "Select * from Courier where IdCourier = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            courier = new Courier();

                            courier.IdCourier = (int)dr["IdCourier"];
                            courier.Firstname = (string)dr["Firstname"];
                            courier.Lastname = (String)dr["Lastname"];
                            courier.Country_code = (int)dr["Country_code"];
                            courier.Email = (String)dr["Email"];
                            courier.Password = (String)dr["Password"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return courier;
        }

        
        //update the information of a courier
        public int UpdateCourier(Courier courier)
        {

            int result = 0;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Courier SET Firstname=@Firstname, Lastname=@Lastname, Country_code=@Country_code, Email=@Email, Password=@Password";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", courier.IdCourier);
                    cmd.Parameters.AddWithValue("@Firstname", courier.Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", courier.Lastname);
                    cmd.Parameters.AddWithValue("@Country_code", courier.Country_code);
                    cmd.Parameters.AddWithValue("@Email", courier.Email);
                    cmd.Parameters.AddWithValue("@Password", courier.Password);
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

        // get a list of courier from a city as idcity entered as parameter
        public List<Courier> GetCouriersSameCity(int idCity)
        {
            throw new NotImplementedException();
        }


        /*
        public int GetCouriersSameCityAndLessThanFiveOrders(int idCity, DateTime DeliveryTime)
        {
            List<Courier> results = null;


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT IdCourier FROM Courier " +
                                    "INNER JOIN Cities ON Courier.Country_code = Cities.IdCity " +
                                    "LEFT JOIN Orders ON Orders.IdCourier = Courier.IdCourier" +
                                    "WHERE IdCity=@id " +
                                    "AND COUNT(Orders.IdOrder)<=5 " +
                                    "AND @DeliveryTime";

                    string query = "SELECT Orders.IdOrder, Orders.Status, Orders.Delivery_time, Orders.IdCustomer, Orders.IdOrder" +
                        ", Order_dishes.Quantity,  Customers.Firstname, Customers.Lastname, (Dishes.Price*Order_dishes.Quantity) AS FinalPrice, " +
                        "Dishes.Name, Customers.Address, Customers.Country_code, Cities.Code, Cities.Name AS CityName FROM Orders " +
                        "LEFT JOIN Customers ON Customers.IdCustomer = Orders.IdCustomer " +
                        "INNER JOIN Order_dishes ON Order_dishes.IdOrder = Orders.IdOrder " +
                        "LEFT JOIN Dishes ON Dishes.IdDishes = Order_dishes.IdDishes " +
                        "LEFT JOIN Cities ON Cities.IdCity = Customers.Country_code " +
                        "WHERE Orders.IdCourier = @id AND NOT Orders.Status='Delivered'";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", idCity);
                    cmd.Parameters.AddWithValue("@DeliveryTime", DeliveryTime);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {


                            if (results == null)
                                results = new List<Courier>();

                            Courier courier = new Courier();


                            courier.IdCourier = (int)dr["IdCourier"];


                            results.Add(courier);
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


        public 

    */

    }
}
