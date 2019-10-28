using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    class Cities : ICities
    {
        public IConfiguration Configuration { get; }
        public Cities(IConfiguration configuration)
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
                    cmd.Parameters.AddWithValue("@Name", Cities.Name);
                    cmd.Parameters.AddWithValue("@Code", Cities.Code);
                    cn.Open();
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

        public List<Cities> getCities()
        {
            
        }

        public Cities getCity(int id)
        {
            
        }
    }
}
