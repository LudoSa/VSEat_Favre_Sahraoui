﻿using Microsoft.Extensions.Configuration;
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

        public Cities GetCity(int id)
        {
            return CitiesDb.GetCity(id);
        }

        public Cities AddCity(Cities hotel)
        {
            return CitiesDb.AddCity(hotel);
        }

        public int DeleteCity(int id)
        {
            return CitiesDb.DeleteCity(id);
        }


    }
}
