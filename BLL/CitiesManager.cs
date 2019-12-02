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


        public ICitiesDB CitiesDbObject { get; }

        public CitiesManager(ICitiesDB citiesDb)
        {

            CitiesDbObject = citiesDb;

        }

        public List<City> GetCities()
        {
            return CitiesDbObject.GetCities();
        }


    }
}
