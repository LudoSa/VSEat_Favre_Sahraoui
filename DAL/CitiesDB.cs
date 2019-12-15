using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public class CitiesDB : ICitiesDB
    {
        private string connectionString = null;


        public CitiesDB(IConfiguration configuration)
        {
            var Config = configuration;
            connectionString = Config.GetConnectionString("DefaultConnection");
        }

        //Get the city which we enter and id
        public City getCity(int id)
        {
            City city = null;


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {


                    string query = "Select * from Cities where IdCity = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            city = new City();

                            city.IdCity = (int)dr["IdCity"];
                            city.Code = (int)dr["Code"];
                            city.Name = (String)dr["Name"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return city;
        }


        //Get a list of cities
        public List<City> GetCities()
        {
            List<City> results = null;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Cities";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<City>();

                            City city = new City();

                            city.IdCity = (int)dr["IdCity"];
                            city.Name = (string)dr["Name"];
                            city.Code = (int)dr["Code"];
                          
                            results.Add(city);
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

        //Get a list of name of the cities
        public List<string> GetNames()
        {
            List<string> results = null;


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Name FROM Cities";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<string>();

                            City city = new City();

                            
                            city.Name = (string)dr["Name"];
                            

                            results.Add(city.Name);
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

        //Get the get the id of a city for a restaurant where we enter the id of the restaurant as a parameter
        public int GetRestaurantCity(int id)
        {
            int idCity =0;


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT IdCity FROM Cities WHERE IdCity=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            idCity = (int)dr["IdCity"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return idCity;
        }
    }
}
