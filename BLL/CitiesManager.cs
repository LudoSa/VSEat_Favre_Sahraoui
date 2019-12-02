using Microsoft.Extensions.Configuration;
using System;
using DTO;
using DAL;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CitiesManager : ICitiesManager
    {


        public ICitiesDB CitiesDb { get; }

        public CitiesManager(IConfiguration configuration)
        {

            CitiesDb = new CitiesDB(configuration);

        }

        public List<City> GetCities()
        {
            return CitiesDb.GetCities();
        }


    }
}
