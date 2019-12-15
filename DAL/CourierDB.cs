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

        

        public List<Courier> GetIdCourier(int idCity)
        {

            List<Courier> courierList = null;


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {


                    string query = "Select * from Courier " +
                        "INNER JOIN Cities ON Cities.IdCity = Courier.Country_Code " +
                        "WHERE IdCity = @idCity";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idCity", idCity);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            if (courierList == null)
                                courierList = new List<Courier>();


                            Courier courier = new Courier();

                            courier.IdCourier = (int)dr["IdCourier"];
                            courier.Firstname = (string)dr["Firstname"];
                            courier.Lastname = (string)dr["Lastname"];
                            courier.Country_code = (int)dr["Country_code"];
                            courier.Email = (string)dr["Email"];
                            courier.Password = (string)dr["Password"];

                            courierList.Add(courier);
                        }

                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return courierList;

        }






    }
}
