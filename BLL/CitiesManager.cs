using Microsoft.Extensions.Configuration;
using System;
using DTO;
using DAL;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CitiesManager
    {


        public ICitiesDB CitiesDb { get; }

        public CitiesManager(IConfiguration configuration)
        {

            CitiesDb = new CitiesDB(configuration);

        }

        public List<Cities> GetCities()
        {
            return CitiesDb.GetCities();
        }


    }
}
