using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    class CitiesDB : ICitiesDB
    {
        public IConfiguration Configuration { get; }
        

        public CitiesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Cities AddCity(Cities city)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using(SqlConnection cn = new SqlConnection(connectionString))
                {
                    String query = "Insert into Cities(Name,Code) values(@Name,@Code); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Name", city.Name);
                    cmd.Parameters.AddWithValue("@Code", city.Code);
                    cn.Open();
                    //city.IdCity = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return city;
        }

        public int DeleteCity(int id)
        {
           
        }

        public List<CitiesDB> getCities()
        {
            
        }

        public CitiesDB getCity(int id)
        {
            
        }
    }
}
