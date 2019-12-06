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

      
    }
}
