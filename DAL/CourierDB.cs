using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    class CourierDB : ICourierDB
    {
        public IConfiguration Configuration { get; }

        public Courier AddCourier(Courier courier)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    String query = "Insert into Courier(Firstname,Lastname,Country_code) values(@Firstname,@Lastname,@Country_code); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Firstname", courier.Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", courier.Lastname);
                    cmd.Parameters.AddWithValue("@Country_code", courier.CountryCode);
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

        public int DeleteCity(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE Courier where IdCourier = @id";
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

        public Courier getCourier(int id)
        {
            Courier courier = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

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
                            courier.CountryCode = (int)dr["Countrycode"];
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

        public List<Courier> getCouriers()
        {
            List<Courier> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Courier";
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
                            courier.Lastname = (string)dr["Lastname"];
                            courier.CountryCode = (int)dr["CountryCode"];

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

        public int UpdateCourier(Courier courier)
        {

            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Courier SET Firstname=@Firstname, Lastname=@Lastname, Country_code=@Countrycode";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", courier.IdCourier);
                    cmd.Parameters.AddWithValue("@Firstname", courier.Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", courier.Lastname);
                    cmd.Parameters.AddWithValue("@Countrycode", courier.CountryCode);
           
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
