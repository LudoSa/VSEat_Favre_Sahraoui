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
        public IConfiguration Configuration { get; }

        public CourierDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }


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
                    cmd.Parameters.AddWithValue("@Country_code", courier.Country_code);
                    cn.Open();
                    courier.IdCourier = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return courier;
        }

        public int DeleteCourier(int id)
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

        public Courier GetCourier(int id)
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
                            courier.Country_code = (int)dr["Country_code"];
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

        

        public int UpdateCourier(Courier courier)
        {

            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Courier SET Firstname=@Firstname, Lastname=@Lastname, Country_code=@Country_code";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", courier.IdCourier);
                    cmd.Parameters.AddWithValue("@Firstname", courier.Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", courier.Lastname);
                    cmd.Parameters.AddWithValue("@Country_code", courier.Country_code);
           
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

        public int DeleteCity(int id)
        {
            throw new NotImplementedException();
        }
    }
}
