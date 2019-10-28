using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class HotelsDB : IHotelsDb
    {
        public IConfiguration Configuration { get; }
        public HotelsDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public int DeleteHotel(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE Hotels where idHotel = @id";
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

        

        public int UpdateHotel(Hotel hotel)
        {

            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Hotels SET Name=@Name, Description=@Description, Location=@Location, Category=@Category, HasWifi=@HasWifi, HasParking=@HasParking, Phone=@Phone, Email=@Email, Website=@Website";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", hotel.IdHotel);
                    cmd.Parameters.AddWithValue("@Name", hotel.Name);
                    cmd.Parameters.AddWithValue("@Description", hotel.Description);
                    cmd.Parameters.AddWithValue("@Location", hotel.Location);
                    cmd.Parameters.AddWithValue("@Category", hotel.Category);
                    cmd.Parameters.AddWithValue("@HasWifi", hotel.HasWifi);
                    cmd.Parameters.AddWithValue("@HasParking", hotel.HasParking);
                    cmd.Parameters.AddWithValue("@Phone", hotel.Phone);
                    cmd.Parameters.AddWithValue("@Email", hotel.Email);
                    cmd.Parameters.AddWithValue("@Website", hotel.Website);

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





        public Hotel AddHotel(Hotel hotel)
        {
            
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Hotels(Name, Description, Location, Category, HasWifi, HasParking, Phone, Email, Website) values(@Name, @Description, @Location, @Category, @HasWifi, @HasParking, @Phone, @Email, @Website); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Name", hotel.Name);
                    cmd.Parameters.AddWithValue("@Description", hotel.Description);
                    cmd.Parameters.AddWithValue("@Location", hotel.Location);
                    cmd.Parameters.AddWithValue("@Category", hotel.Category);
                    cmd.Parameters.AddWithValue("@HasWifi", hotel.HasWifi);
                    cmd.Parameters.AddWithValue("@HasParking", hotel.HasParking);
                    cmd.Parameters.AddWithValue("@Phone", hotel.Phone);
                    cmd.Parameters.AddWithValue("@Email", hotel.Email);
                    cmd.Parameters.AddWithValue("@Website", hotel.Website);

                    cn.Open();

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return hotel;
        }






        public Hotel GetHotel(int id)
        {
            Hotel hotel = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                 

                    string query = "Select * from Hotels where idHotel = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            hotel = new Hotel();

                            hotel.IdHotel = (int)dr["idHotel"];
                            hotel.Name = (string)dr["Name"];
                            hotel.Description = (string)dr["Description"];
                            hotel.Location = (string)dr["Location"];
                            hotel.Category = (int)dr["Category"];
                            hotel.HasWifi = (bool)dr["HasWifi"];
                            hotel.HasParking = (bool)dr["HasParking"];

                            if (dr["Phone"] != null)
                                hotel.Phone = (string)dr["Phone"];

                            if (dr["Email"] != null)
                                hotel.Email = (string)dr["Email"];

                            if (dr["Website"] != null)
                                hotel.Website = (string)dr["Website"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return hotel;

        }


        public List<Hotel> GetHotels()
        {
            List<Hotel> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
                                                                                         
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Hotels";
                    SqlCommand cmd = new SqlCommand(query, cn);
                   
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Hotel>();

                            Hotel hotel = new Hotel();

                            hotel.IdHotel = (int)dr["idHotel"];
                            hotel.Name = (string)dr["Name"];
                            hotel.Description = (string)dr["Description"];
                            hotel.Location = (string)dr["Location"];
                            hotel.Category = (int)dr["Category"];
                            hotel.HasWifi = (bool)dr["HasWifi"];
                            hotel.HasParking = (bool)dr["HasParking"];

                            if (dr["Phone"] != null)
                                hotel.Phone = (string)dr["Phone"];

                            if (dr["Email"] != null)
                                hotel.Email = (string)dr["Email"];

                            if (dr["Website"] != null)
                                hotel.Website = (string)dr["Website"];

                            results.Add(hotel);
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
