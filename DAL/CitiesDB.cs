﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public class CitiesDB : ICitiesDB
    {
        public IConfiguration Configuration { get; }
        

        public CitiesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

       

       

        public List<Cities> GetCities()
        {
            List<Cities> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

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
                                results = new List<Cities>();

                            Cities city = new Cities();

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
    }
}
